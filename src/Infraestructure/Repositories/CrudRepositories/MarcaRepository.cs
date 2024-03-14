using Domain.Data;
using Domain.Models.Articulo;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class MarcaRepository : CrudRepository<Marca>
    {
        public MarcaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Marca, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];
    }
}
