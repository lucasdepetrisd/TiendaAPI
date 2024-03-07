using Application.DTOs;

namespace Application.Contracts
{
    public interface IVentaService : IBaseService<CreateVentaDTO, VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId);
        Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId);
        Task<VentaDTO> QuitarLineaDeVenta(int idVenta, int idLineaDeVenta);
        Task<VentaDTO> ActualizarMonto(int idVenta);
        Task<VentaDTO> CancelarVenta(int idVenta);
    }
}