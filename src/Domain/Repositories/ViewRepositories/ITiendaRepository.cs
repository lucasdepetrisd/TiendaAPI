using Domain.Models;

namespace Domain.Repositories.ViewRepositories
{
    public interface ITiendaRepository : IViewRepository<Tienda>
    {
        Task<Tienda?> GetFirstOrDefault();
    }
}
