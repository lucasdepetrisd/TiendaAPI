using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TalleRepository : BaseRepository<Talle>
    {
        public TalleRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Talle, object>>[] NavigationPropertiesToLoad
        => [a => a.TipoTalle!];
    }
}
