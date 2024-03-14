using Application.Contracts.ViewServices;
using Application.DTOs;
using Application.DTOs.Ventas;
using Domain.Models.Ventas;

namespace Application.Contracts.UseCasesServices
{
    public interface IPagoService : IViewService<PagoDTO>
    {
        Task<Venta> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta);
        Task<Venta> ProcesarPagoEnEfectivo(Venta venta);
    }
}