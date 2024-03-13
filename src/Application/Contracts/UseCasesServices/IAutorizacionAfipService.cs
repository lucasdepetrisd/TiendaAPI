using Domain.Models;

namespace Application.Contracts.UseCasesServices
{
    public interface IAutorizacionAfipService
    {
        Task<bool> AutorizarAfip(Venta venta);
    }
}