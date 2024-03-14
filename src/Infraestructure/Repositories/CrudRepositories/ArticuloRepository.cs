using Domain.Data;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class ArticuloRepository : CrudRepository<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Articulo, object>>[] NavigationPropertiesToLoad
        => [a => a.Categoria!, a => a.Marca!, a => a.TipoTalle!];

        public async Task<Articulo?> GetByCodigoAsync(string codigo)
        {
            var query = _tiendaContext.Articulo.AsQueryable();

            query = query.Where(a => a.Codigo == codigo);

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            return await query.SingleOrDefaultAsync();
        }
    }
}
