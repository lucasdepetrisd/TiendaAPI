using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IPagoService : IBaseService<CreatePagoDTO, PagoDTO>
    {
        Task<bool> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta);
        Task<bool> ProcesarPagoEnEfectivo(Venta venta);
    }
}