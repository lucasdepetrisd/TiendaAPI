using Domain.Data;
using Domain.Models.Admin;
using Infraestructure.Repositories.ViewRepositories;
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
