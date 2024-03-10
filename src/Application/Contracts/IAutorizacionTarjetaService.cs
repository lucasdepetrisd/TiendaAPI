using Application.DTOs;
using Domain.Models;

namespace Application.Services
{
    public interface IAutorizacionTarjetaService
    {
        Task<bool> Autorizar(Venta venta, TarjetaDTO datosTarjeta);
    }
}