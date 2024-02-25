using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class ArticuloRepository : BaseRepository<Articulo>
    {
        public ArticuloRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Articulo, object>>[] NavigationPropertiesToLoad
        => [a => a.Categoria!, a => a.Marca!, a => a.TipoTalle!];
    }
}
