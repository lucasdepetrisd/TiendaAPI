using Application.Contracts.ViewServices;
using Application.DTOs;
using Domain.Models;

namespace Application.Contracts.UseCasesServices
{
    public interface IPagoService : IViewService<PagoDTO>
    {
        Task<Venta> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta);
        Task<Venta> ProcesarPagoEnEfectivo(Venta venta);
    }
}