using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class RolRepository : BaseRepository<Rol>
    {
        public RolRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Rol, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuarios];
    }
}
