using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class VentaService : BaseService<Venta, CreateVentaDTO, VentaDTO>, IVentaService
    {
        private readonly IRepository<Venta> _ventaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRepository<PuntoDeVenta> _puntoDeVentaRepository;
        private readonly IRepository<Inventario> _inventarioRepository;

        public VentaService(
            IRepository<Venta> ventaRepository,
            IUsuarioRepository usuarioRepository,
            IRepository<PuntoDeVenta> puntoDeVentaRepository,
            IRepository<Inventario> inventarioRepository,
            IMapper mapper)
            : base(ventaRepository, mapper)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _usuarioRepository = usuarioRepository;
            _puntoDeVentaRepository = puntoDeVentaRepository;
            _inventarioRepository = inventarioRepository;
        }

        public async Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            var puntoDeVenta = await _puntoDeVentaRepository.GetByIdAsync(puntoDeVentaId);

            if (usuario == null)
            {
                throw new InvalidOperationException($"Usuario with ID {usuarioId} not found.");
            }
            else if (puntoDeVenta == null)
            {
                throw new InvalidOperationException($"Punto de Venta with ID {puntoDeVentaId} not found.");
            }

            var venta = new Venta(usuario, puntoDeVenta);

            await _ventaRepository.AddAsync(venta);

            VentaDTO nuevaVenta = _mapper.Map<VentaDTO>(venta);

            return nuevaVenta;
        }

        public async Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId)
        {
            var venta = await _ventaRepository.GetByIdAsync(ventaId);
            var inventario = await _inventarioRepository.GetByIdAsync(inventarioId);

            if (venta == null)
            {
                throw new InvalidOperationException($"Venta with ID {ventaId} not found.");
            }
            else if (inventario == null)
            {
                throw new InvalidOperationException($"Inventario with ID {inventarioId} not found.");
            }

            var lineaDeVenta = venta.AgregarLineaDeVenta(cantidad, inventario);

            await _ventaRepository.UpdateAsync(venta);

            LineaDeVentaDTO lineaDeVentaDTO = _mapper.Map<LineaDeVentaDTO>(lineaDeVenta);

            return lineaDeVentaDTO;
        }
    }
}
