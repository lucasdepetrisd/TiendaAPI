using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class VentaService : BaseService<Venta, CreateVentaDTO, VentaDTO>, IVentaService
    {
        private readonly IRepository<Venta> _ventaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRepository<PuntoDeVenta> _puntoDeVentaRepository;
        private readonly IRepository<Inventario> _inventarioRepository;
        private readonly IRepository<LineaDeVenta> _lineaDeVentaRepository;

        public VentaService(
            IRepository<Venta> ventaRepository,
            IUsuarioRepository usuarioRepository,
            IRepository<PuntoDeVenta> puntoDeVentaRepository,
            IRepository<Inventario> inventarioRepository,
            IRepository<LineaDeVenta> lineaDeVentaRepository,
            IMapper mapper)
            : base(ventaRepository, mapper)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _usuarioRepository = usuarioRepository;
            _puntoDeVentaRepository = puntoDeVentaRepository;
            _inventarioRepository = inventarioRepository;
            _lineaDeVentaRepository = lineaDeVentaRepository;
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

        public async Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId);
            var inventario = await _inventarioRepository.GetByIdAsync(inventarioId);

            if (venta == null)
            {
                throw new InvalidOperationException($"Venta con ID {ventaId} no encontrado.");
            }
            else if (inventario == null)
            {
                throw new InvalidOperationException($"Inventario con ID {inventarioId} no encontrado.");
            }

            var lineaDeVenta = venta.AgregarLineaDeVenta(cantidad, inventario);

            await _ventaRepository.UpdateAsync(venta);

            LineaDeVentaDTO lineaDeVentaDTO = _mapper.Map<LineaDeVentaDTO>(lineaDeVenta);

            return lineaDeVentaDTO;
        }

        public async Task<VentaDTO> QuitarLineaDeVenta(int idVenta, int idLineaDeVenta)
        {
            var venta = await _ventaRepository.GetByIdAsync(idVenta);

            if (venta == null)
            {
                throw new InvalidOperationException("Venta con ID {ventaId} no encontrado.");
            }

            venta.QuitarLineaDeVenta(idLineaDeVenta);

            await _lineaDeVentaRepository.RemoveAsync(idLineaDeVenta);
            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }

        public async Task<VentaDTO> ActualizarMonto(int idVenta)
        {
            var venta = await _ventaRepository.GetByIdAsync(idVenta);

            if (venta == null)
            {
                throw new InvalidOperationException("Venta con ID {ventaId} no encontrado.");
            }

            venta.ActualizarMonto();

            await _ventaRepository.UpdateAsync(venta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }
    }
}
