using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TalleRepository : CrudRepository<Talle>
    {
        public TalleRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Talle, object>>[] NavigationPropertiesToLoad
        => [a => a.TipoTalle!];
    }
}
