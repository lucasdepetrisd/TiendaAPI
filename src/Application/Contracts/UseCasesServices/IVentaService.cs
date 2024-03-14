using Application.Contracts.ViewServices;
using Application.DTOs;
using Application.DTOs.Ventas;

namespace Application.Contracts.UseCasesServices
{
    public interface IVentaService : IViewService<VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int sesionId);
        Task<VentaDTO> ActualizarMonto(int idVenta);
        Task<VentaDTO> CancelarVenta(int idVenta);
        Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta);
        Task<VentaDTO> ModificarCliente(int ventaId, int clienteId);
    }
}