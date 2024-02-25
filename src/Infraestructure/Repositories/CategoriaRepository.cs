using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class CategoriaRepository : BaseRepository<Categoria>
    {
        public CategoriaRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Categoria, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];
    }
}
