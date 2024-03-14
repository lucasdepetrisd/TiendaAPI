using Domain.Models.Admin;

namespace Domain.Repositories.ViewRepositories
{
    public interface ITiendaRepository : IViewRepository<Tienda>
    {
        Task<Tienda?> GetFirstOrDefault();
    }
}
