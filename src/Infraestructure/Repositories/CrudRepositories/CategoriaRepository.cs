using Domain.Data;
using Domain.Models.Articulo;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class CategoriaRepository : CrudRepository<Categoria>
    {
        public CategoriaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Categoria, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];
    }
}
