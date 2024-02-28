using Domain.DTOs;

namespace Application.Contracts
{
    public interface IVentaService : IBaseService<CreateVentaDTO, VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId);
        Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId);
    }
}