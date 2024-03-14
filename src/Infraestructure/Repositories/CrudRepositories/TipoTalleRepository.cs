using Domain.Data;
using Domain.Models.Articulo;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TipoTalleRepository : CrudRepository<TipoTalle>
    {
        public TipoTalleRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<TipoTalle, object>>[] NavigationPropertiesToLoad
        => [a => a.Talles];
    }
}
