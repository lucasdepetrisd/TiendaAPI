using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class CondicionTributariaRepository : BaseRepository<CondicionTributaria>
    {
        public CondicionTributariaRepository(TiendaContext context)
            : base(context)
        {
        }
        protected override Expression<Func<CondicionTributaria, object>>[] NavigationPropertiesToLoad
        => [a => a.TipoDeComprobante];
    }
}
