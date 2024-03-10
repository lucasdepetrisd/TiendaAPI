using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class VentaService : BaseService<Venta, CreateVentaDTO, VentaDTO>, IVentaService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRepository<Venta> _ventaRepository;
        private readonly IRepository<PuntoDeVenta> _puntoDeVentaRepository;

        private readonly IPagoService _pagoService;

        public VentaService(
            IRepository<Venta> ventaRepository,
            IUsuarioRepository usuarioRepository,
            IRepository<PuntoDeVenta> puntoDeVentaRepository,
            IRepository<Inventario> inventarioRepository,
            IMapper mapper,
            IPagoService pagoService)
            : base(ventaRepository, mapper)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _usuarioRepository = usuarioRepository;
            _puntoDeVentaRepository = puntoDeVentaRepository;

            _pagoService = pagoService;
        }

        public async Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            var puntoDeVenta = await _puntoDeVentaRepository.GetByIdAsync(puntoDeVentaId);

            if (usuario == null)
            {
                throw new InvalidOperationException($"Usuario con ID {usuarioId} no encontrado.");
            }
            else if (puntoDeVenta == null)
            {
                throw new InvalidOperationException($"Punto de Venta con ID {puntoDeVentaId} no encontrado.");
            }

            var venta = new Venta(usuario, puntoDeVenta);

            await _ventaRepository.AddAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO> CancelarVenta(int ventaId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId);

            if (venta == null)
            {
                throw new InvalidOperationException($"Venta con ID {ventaId} no encontrado.");
            }

            venta.Cancelar();

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO> ActualizarMonto(int ventaId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId);

            if (venta == null)
            {
                throw new InvalidOperationException($"Venta con ID {ventaId} no encontrado.");
            }

            venta.CalcularTotal();

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId);
            bool pagoAprobado;

            if (venta == null)
            {
                throw new InvalidOperationException($"Venta con ID {ventaId} no encontrado.");
            }

            if (esTarjeta)
            {
                if (datosTarjeta != null)
                {
                    pagoAprobado = await _pagoService.ProcesarPagoConTarjeta(venta, datosTarjeta);
                }
                else
                {
                    throw new InvalidOperationException($"datosTarjeta no debe ser null");
                }
            }
            else
            {
                pagoAprobado = await _pagoService.ProcesarPagoEnEfectivo(venta);
            }

            if (pagoAprobado)
            {
                await _ventaRepository.UpdateAsync(venta);

                VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

                return nuevaVentaDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
