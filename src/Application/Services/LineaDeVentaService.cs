using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class LineaDeVentaService : CrudService<LineaDeVenta, CreateLineaDeVentaDTO, LineaDeVentaDTO>, ILineaDeVentaService
    {
        private readonly ICrudRepository<LineaDeVenta> _lineaDeVentaRepository;
        private readonly ICrudRepository<Venta> _ventaRepository;
        private readonly ICrudRepository<Inventario> _inventarioRepository;

        public LineaDeVentaService(
            ICrudRepository<LineaDeVenta> lineaDeVentaRepository,
            IMapper mapper,
            ICrudRepository<Venta> ventaRepository,
            ICrudRepository<Inventario> inventarioRepository) : base(lineaDeVentaRepository, mapper)
        {
            _lineaDeVentaRepository = lineaDeVentaRepository ?? throw new ArgumentNullException(nameof(lineaDeVentaRepository));
            _ventaRepository = ventaRepository;
            _inventarioRepository = inventarioRepository;
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
            var venta = await _ventaRepository.GetByIdAsync(idVenta) ?? throw new InvalidOperationException("Venta con ID {ventaId} no encontrado.");
            venta.QuitarLineaDeVenta(idLineaDeVenta);

            await _ventaRepository.UpdateAsync(venta);
            await _lineaDeVentaRepository.RemoveAsync(idLineaDeVenta);

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }
    }
}
