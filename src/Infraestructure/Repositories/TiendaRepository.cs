using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TiendaRepository : BaseRepository<Tienda>
    {
        public TiendaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Tienda, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursales];

        public override Task AddAsync(Tienda entity)
        {
            throw new NotSupportedException("AddAsync method is not supported in TiendaRepository.");
        }

        public override Task RemoveAsync(Tienda entity)
        {
            throw new NotSupportedException("RemoveAsync method is not supported in TiendaRepository.");
        }
    }
}
