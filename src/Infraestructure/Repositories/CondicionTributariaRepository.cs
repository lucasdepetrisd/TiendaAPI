using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class CondicionTributariaRepository : BaseRepository<CondicionTributaria>
    {
        public CondicionTributariaRepository(ITiendaContext context)
            : base(context)
        {
        }
        protected override Expression<Func<CondicionTributaria, object>>[] NavigationPropertiesToLoad
        => [a => a.TiposDeComprobantesEmisor, a => a.TiposDeComprobantesReceptor];

        public override Task AddAsync(CondicionTributaria condicionTributaria)
        {
            throw new NotSupportedException("AddAsync method is not supported in CondicionTributariaRepository.");
        }

        public override Task RemoveAsync(int id)
        {
            throw new NotSupportedException("RemoveAsync method is not supported in CondicionTributariaRepository.");
        }
    }
}
