using Domain.Data;
using Domain.Models.Admin;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class ClienteRepository : CrudRepository<Cliente>
    {
        public ClienteRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Cliente, object>>[] NavigationPropertiesToLoad
        => [a => a.CondicionTributaria!, a => a.Ventas!];
    }
}
