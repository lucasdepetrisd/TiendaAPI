using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.ViewRepositories;

namespace Application.Services.UseCasesServices
{
    /* 
     * Utilizo ViewService para evitar que se pueda realizar CRUD 
     * utilizando la capa de aplicación, pero si que el servicio 
     * pueda llamar a su repositorio CRUD tras realizar lógica de negocios.
    */
    public class VentaService : ViewService<Venta, VentaDTO>, IVentaService
    {
        private readonly ICrudRepository<Venta> _ventaRepository;
        private readonly ICrudRepository<PuntoDeVenta> _puntoDeVentaRepository;
        private readonly ICrudRepository<Cliente> _clienteRepository;
        private readonly ICrudRepository<Sesion> _sesionRepository;
        private readonly ITiendaRepository _tiendaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IPagoService _pagoService;

        public VentaService(
            ICrudRepository<Venta> ventaRepository,
            ICrudRepository<PuntoDeVenta> puntoDeVentaRepository,
            //IRepository<Inventario> inventarioRepository,
            ICrudRepository<Cliente> clienteRepository,
            ICrudRepository<Sesion> sesionRepository,
            IUsuarioRepository usuarioRepository,
            ITiendaRepository tiendaRepository,
            IMapper mapper,
            IPagoService pagoService)
            : base(ventaRepository, mapper)
        {
            _pagoService = pagoService ?? throw new ArgumentNullException(nameof(pagoService));

            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _puntoDeVentaRepository = puntoDeVentaRepository ?? throw new ArgumentNullException(nameof(puntoDeVentaRepository));

            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _tiendaRepository = tiendaRepository ?? throw new ArgumentNullException(nameof(tiendaRepository));
            _sesionRepository = sesionRepository ?? throw new ArgumentNullException(nameof(sesionRepository));
        }

        public async Task<VentaDTO> IniciarVenta(int sesionId)
        {
            var sesion = await _sesionRepository.GetByIdAsync(sesionId) ?? throw new InvalidOperationException($"Sesion con ID {sesionId} no encontrada.");

            if (sesion.FechaFin != null)
            {
                throw new InvalidOperationException("Inicie sesión para iniciar una venta.");
            }

            var puntoDeVenta = await _puntoDeVentaRepository.GetByIdAsync(sesion.IdPuntoDeVenta) ?? throw new InvalidOperationException($"Punto de Venta con ID {sesion.IdPuntoDeVenta} no encontrado.");
            var usuario = await _usuarioRepository.GetByIdAsync(sesion.IdUsuario) ?? throw new InvalidOperationException($"Usuario con ID {sesion.IdUsuario} no encontrado.");

            //Considerar convertir defaultCliente a metodo del repositorio
            var defaultCliente = await _clienteRepository.GetByIdAsync(0) ?? throw new InvalidOperationException($"Cliente predeterminado no encontrado.");
            var tienda = await _tiendaRepository.GetFirstOrDefault() ?? throw new InvalidOperationException($"Tienda no encontrada.");

            Empleado empleado = usuario.Empleado;

            if (empleado.Sucursal.IdSucursal != puntoDeVenta.Sucursal.IdSucursal)
            {
                throw new InvalidOperationException($"No se puede realizar la operación. Empleado con ID {empleado.IdEmpleado} no asignado a la Sucursal {puntoDeVenta.Sucursal.Nombre}.");
            }

            var venta = new Venta(usuario, puntoDeVenta, defaultCliente, tienda.CondicionTributaria);

            await _ventaRepository.AddAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO> CancelarVenta(int ventaId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrada.");
            venta.Cancelar();

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO> ActualizarMonto(int ventaId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrada.");
            venta.CalcularTotal();

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrada.");
            Venta ventaPagada;

            if (venta.Estado.Equals("finalizada", StringComparison.CurrentCultureIgnoreCase)
                || venta.Estado.Equals("cancelada", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new InvalidOperationException($"Venta con ID {ventaId} ya finalizada o cancelada.");
            }
            
            // Antes de finalizar reviso que las lineas de ventas tengan inventarios válidos
            foreach (var lineaDeVenta in venta.LineasDeVentas)
            {
                if (lineaDeVenta.Inventario == null)
                {
                    throw new InvalidOperationException($"Inventario con ID {lineaDeVenta.IdInventario} no encontrado. No se puede finalizar la venta.");
                } 
                else if (lineaDeVenta.Cantidad > lineaDeVenta.Inventario.Cantidad) 
                {
                    throw new InvalidOperationException($"Inventario con ID {lineaDeVenta.IdInventario} no posee cantidad suficiente. No se puede finalizar la venta.");
                }
            }

            if (esTarjeta)
            {
                if (datosTarjeta != null)
                {
                    ventaPagada = await _pagoService.ProcesarPagoConTarjeta(venta, datosTarjeta);
                }
                else
                {
                    throw new InvalidOperationException($"datosTarjeta no debe ser null");
                }
            }
            else
            {
                ventaPagada = await _pagoService.ProcesarPagoEnEfectivo(venta);
            }

            if (ventaPagada.Pago != null && !ventaPagada.Pago.Estado.Equals("aprobado", StringComparison.CurrentCultureIgnoreCase))
            {
                return null;
            }

            foreach (var lineaDeVenta in ventaPagada.LineasDeVentas)
            {
                var inventario = lineaDeVenta.Inventario;
                inventario.Cantidad -= lineaDeVenta.Cantidad;
            }

            ventaPagada.Finalizar();

            await _ventaRepository.UpdateAsync(ventaPagada);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(ventaPagada);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO> ModificarCliente(int ventaId, int clienteId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrada.");
            var cliente = await _clienteRepository.GetByIdAsync(clienteId) ?? throw new InvalidOperationException($"Cliente con ID {clienteId} no encontrado.");
            var tienda = await _tiendaRepository.GetFirstOrDefault() ?? throw new InvalidOperationException($"Tienda no encontrada.");

            venta.ModificarCliente(cliente, tienda.CondicionTributaria);

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }
    }
}
