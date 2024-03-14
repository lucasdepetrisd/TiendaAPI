using Domain.Data;
using Domain.Models.Admin;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class RolRepository : CrudRepository<Rol>
    {
        public RolRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Rol, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuarios];
    }
}
