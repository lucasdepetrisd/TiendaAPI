using Domain.Models;

namespace Domain.Repositories
{
    public interface IArticuloRepository : ICrudRepository<Articulo>
    {
        Task<Articulo?> GetByCodigoAsync(string codigo);
    }
}
