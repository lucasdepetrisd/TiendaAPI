using Application.DTOs;

namespace Application.Contracts
{
    public interface IVentaService : IViewService<VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId);
        Task<VentaDTO> ActualizarMonto(int idVenta);
        Task<VentaDTO> CancelarVenta(int idVenta);
        Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta);
        Task<VentaDTO> ModificarCliente(int ventaId, int clienteId);
    }
}