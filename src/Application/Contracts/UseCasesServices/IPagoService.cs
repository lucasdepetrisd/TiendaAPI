using Application.Contracts.ViewServices;
using Application.DTOs;
using Application.DTOs.Ventas;
using Domain.Models.Ventas;

namespace Application.Contracts.UseCasesServices
{
    public interface IPagoService : IViewService<PagoDTO>
    {
        Task<(Pago pago, long nroComprobante)> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta);
        Task<(Pago pago, long nroComprobante)> ProcesarPagoEnEfectivo(Venta venta);
    }
}