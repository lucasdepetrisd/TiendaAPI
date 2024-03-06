using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TipoDeComprobanteRepository : BaseRepository<TipoDeComprobante>
    {
        public TipoDeComprobanteRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<TipoDeComprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.Emisor, a => a.Receptor];
    }
}
