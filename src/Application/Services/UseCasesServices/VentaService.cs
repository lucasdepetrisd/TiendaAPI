using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.DTOs.Ventas;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Models.Articulo;
using Domain.Models.Ventas;
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
        //TODO: Mover DI de repositorios a Unit of Work
        private readonly ICrudRepository<Venta> _ventaRepository;
        private readonly ICrudRepository<LineaDeVenta> _lineaDeVentaRepository;
        private readonly ICrudRepository<PuntoDeVenta> _puntoDeVentaRepository;
        private readonly ICrudRepository<Cliente> _clienteRepository;
        private readonly ICrudRepository<Sesion> _sesionRepository;
        private readonly ICrudRepository<Inventario> _inventarioRepository;
        private readonly ITiendaRepository _tiendaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly ILineaDeVentaService _lineaDeVentaService;
        private readonly IPagoService _pagoService;

        public VentaService(
            ICrudRepository<Venta> ventaRepository,
            ICrudRepository<LineaDeVenta> lineaDeVentaRepository,
            ICrudRepository<PuntoDeVenta> puntoDeVentaRepository,
            ICrudRepository<Cliente> clienteRepository,
            ICrudRepository<Sesion> sesionRepository,
            ICrudRepository<Inventario> inventarioRepository,
            IUsuarioRepository usuarioRepository,
            ITiendaRepository tiendaRepository,
            IMapper mapper,
            ILineaDeVentaService lineaDeVentaService,
            IPagoService pagoService
            )
            : base(ventaRepository, mapper)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _lineaDeVentaRepository = lineaDeVentaRepository ?? throw new ArgumentNullException(nameof(lineaDeVentaRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _puntoDeVentaRepository = puntoDeVentaRepository ?? throw new ArgumentNullException(nameof(puntoDeVentaRepository));

            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _tiendaRepository = tiendaRepository ?? throw new ArgumentNullException(nameof(tiendaRepository));
            _sesionRepository = sesionRepository ?? throw new ArgumentNullException(nameof(sesionRepository));
            _inventarioRepository = inventarioRepository ?? throw new ArgumentNullException(nameof(inventarioRepository));

            _pagoService = pagoService ?? throw new ArgumentNullException(nameof(pagoService));
            _lineaDeVentaService = lineaDeVentaService ?? throw new ArgumentNullException(nameof(lineaDeVentaService));
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

        public async Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrada.");
            Pago pago;
            long nroComprobante;

            if (!venta.PuedeFinalizar(out string errorMessage))
            {
                throw new InvalidOperationException(errorMessage);
            }

            if (esTarjeta)
            {
                if (datosTarjeta == null)
                {
                    throw new InvalidOperationException("datosTarjeta no debe ser null");
                }

                (pago, nroComprobante) = await _pagoService.ProcesarPagoConTarjeta(venta, datosTarjeta);
            }
            else
            {
                (pago, nroComprobante) = await _pagoService.ProcesarPagoEnEfectivo(venta);
            }

            if (pago == null || pago.Estado != EstadoPago.Aprobado)
            {
                return null;
            }

            venta.AgregarPago(pago);

            venta.Finalizar(nroComprobante);

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO ventaFinalizadaDTO = _mapper.Map<VentaDTO>(venta);

            return ventaFinalizadaDTO;
        }

        public async Task<VentaDTO> ModificarCliente(int ventaId, int clienteId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrada.");
            var cliente = await _clienteRepository.GetByIdAsync(clienteId) ?? throw new InvalidOperationException($"Cliente con ID {clienteId} no encontrado.");
            var tienda = await _tiendaRepository.GetFirstOrDefault() ?? throw new InvalidOperationException($"Tienda no encontrada.");

            venta.ModificarCliente(cliente, tienda.CondicionTributaria);

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO ventaModificadaDTO = _mapper.Map<VentaDTO>(venta);

            return ventaModificadaDTO;
        }

        public async Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrado.");
            var inventario = await _inventarioRepository.GetByIdAsync(inventarioId) ?? throw new InvalidOperationException($"Inventario con ID {inventarioId} no encontrado.");

            var lineaDeVenta = venta.AgregarLineaDeVenta(cantidad, inventario);

            await _ventaRepository.UpdateAsync(venta);

            LineaDeVentaDTO lineaDeVentaDTO = _mapper.Map<LineaDeVentaDTO>(lineaDeVenta);

            return lineaDeVentaDTO;
        }

        public async Task<VentaDTO> QuitarLineaDeVenta(int ventaId, int lineaDeVentaId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId) ?? throw new InvalidOperationException($"Venta con ID {ventaId} no encontrado.");
            venta.QuitarLineaDeVenta(lineaDeVentaId);

            await _ventaRepository.UpdateAsync(venta);
            await _lineaDeVentaRepository.RemoveAsync(lineaDeVentaId);

            VentaDTO ventaModificadaDTO = _mapper.Map<VentaDTO>(venta);

            return ventaModificadaDTO;
        }
    }
}
