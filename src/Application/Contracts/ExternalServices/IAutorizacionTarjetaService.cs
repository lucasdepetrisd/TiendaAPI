using Application.DTOs;
using Domain.Models;

namespace Application.Contracts.ExternalServices
{
    public interface IAutorizacionTarjetaService
    {
        Task<bool> Autorizar(Venta venta, TarjetaDTO datosTarjeta);
    }
}