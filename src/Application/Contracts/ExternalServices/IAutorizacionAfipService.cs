using Domain.Models.Ventas;

namespace Application.Contracts.ExternalServices
{
    public interface IAutorizacionAfipService
    {
        Task<(bool, long?, string?)> AutorizarAfip(Pago pago);
    }
}