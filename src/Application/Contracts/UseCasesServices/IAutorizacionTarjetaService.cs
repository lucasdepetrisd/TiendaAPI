using Application.DTOs;
using Domain.Models;

namespace Application.Contracts.UseCasesServices
{
    public interface IAutorizacionTarjetaService
    {
        Task<bool> Autorizar(Venta venta, TarjetaDTO datosTarjeta);
    }
}