using Domain.Models;

namespace Domain.Repositories
{
    public interface IArticuloRepository : IRepository<Articulo>
    {
        Task<Articulo?> GetByCodigoAsync(string codigo);
    }
}
