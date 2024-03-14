using Domain.Models;

namespace Application.Contracts.ExternalServices
{
    public interface IAutorizacionAfipService
    {
        Task<(bool, long?)> AutorizarAfip(Venta venta);
    }
}