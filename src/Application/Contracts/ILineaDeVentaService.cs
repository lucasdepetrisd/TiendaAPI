using Application.DTOs;

namespace Application.Contracts
{
    public interface ILineaDeVentaService : IBaseService<CreateLineaDeVentaDTO, LineaDeVentaDTO>
    {
        Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId);
        Task<VentaDTO> QuitarLineaDeVenta(int idVenta, int idLineaDeVenta);
    }
}