using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TipoDeComprobanteRepository : BaseRepository<TipoDeComprobante>
    {
        public TipoDeComprobanteRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<TipoDeComprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.CondicionesTributarias];
    }
}
