using Application.DTOs;

namespace Application.Contracts
{
    public interface IVentaService : IBaseService<CreateVentaDTO, VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId);
        Task<VentaDTO> ActualizarMonto(int idVenta);
        Task<VentaDTO> CancelarVenta(int idVenta);
        Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta);
    }
}