using Domain.Models;

namespace Domain.Repositories
{
    public interface ITiendaRepository : IViewRepository<Tienda>
    {
        Task<Tienda?> GetFirstOrDefault();
    }
}
