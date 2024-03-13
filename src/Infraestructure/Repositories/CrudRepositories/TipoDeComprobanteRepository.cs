using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.CrudRepositories
{
    internal class TipoDeComprobanteRepository : CrudRepository<TipoDeComprobante>
    {
        public TipoDeComprobanteRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<TipoDeComprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.CondicionTributariaEmisor, a => a.CondicionTributariaReceptor];
    }
}
