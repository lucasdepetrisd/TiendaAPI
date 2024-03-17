using Application.Contracts.ViewServices;
using Application.DTOs;
using Application.DTOs.Ventas;

namespace Application.Contracts.UseCasesServices
{
    public interface IVentaService : IViewService<VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int sesionId);
        Task<VentaDTO> CancelarVenta(int ventaId);
        Task<VentaDTO?> FinalizarVenta(int ventaId, bool esTarjeta, TarjetaDTO? datosTarjeta);
        Task<VentaDTO> ModificarCliente(int ventaId, int clienteId);
        Task<LineaDeVentaDTO> AgregarLineaDeVenta(int ventaId, int cantidad, int inventarioId);
        Task<VentaDTO> QuitarLineaDeVenta(int ventaId, int lineaDeVentaId);
    }
}