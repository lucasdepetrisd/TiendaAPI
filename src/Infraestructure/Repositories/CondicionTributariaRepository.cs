using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class CondicionTributariaRepository : ViewRepository<CondicionTributaria>
    {
        public CondicionTributariaRepository(ITiendaContext context)
            : base(context)
        {
        }
        protected override Expression<Func<CondicionTributaria, object>>[] NavigationPropertiesToLoad
        => [];
    }
}
