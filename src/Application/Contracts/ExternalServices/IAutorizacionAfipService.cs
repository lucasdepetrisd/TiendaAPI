using Domain.Models;

namespace Application.Contracts.ExternalServices
{
    public interface IAutorizacionAfipService
    {
        Task<bool> AutorizarAfip(Venta venta);
    }
}