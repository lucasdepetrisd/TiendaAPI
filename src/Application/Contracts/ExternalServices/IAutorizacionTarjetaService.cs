using Application.DTOs;
using Domain.Models.Ventas;

namespace Application.Contracts.ExternalServices
{
    public interface IAutorizacionTarjetaService
    {
        Task<bool> AutorizarTarjeta(Venta venta, TarjetaDTO datosTarjeta);
    }
}