using Application.Contracts.UseCasesServices;
using Application.DTOs.Ventas;
using Application.Services.CrudServices;
using AutoMapper;
using Domain.Models.Articulo;
using Domain.Models.Ventas;
using Domain.Repositories;

namespace Application.Services.UseCasesServices
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

            VentaDTO nuevaVentaDTO = _mapper.Map<VentaDTO>(venta);

            return nuevaVentaDTO;
        }
    }
}
