using Application.DTOs;

namespace Application.Contracts
{
    public interface ILineaDeVentaService : IViewService<LineaDeVentaDTO>
    {
        Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId);
        Task<VentaDTO> QuitarLineaDeVenta(int idVenta, int idLineaDeVenta);
    }
}