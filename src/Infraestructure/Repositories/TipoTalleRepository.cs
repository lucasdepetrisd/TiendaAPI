using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TipoTalleRepository : BaseRepository<TipoTalle>
    {
        public TipoTalleRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<TipoTalle, object>>[] NavigationPropertiesToLoad
        => [a => a.Talles];
    }
}
