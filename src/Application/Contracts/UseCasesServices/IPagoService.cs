using Application.Contracts.ViewServices;
using Application.DTOs;
using Domain.Models;

namespace Application.Contracts.UseCasesServices
{
    public interface IPagoService : IViewService<PagoDTO>
    {
        Task<bool> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta);
        Task<bool> ProcesarPagoEnEfectivo(Venta venta);
    }
}