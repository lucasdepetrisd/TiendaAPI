using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class RolRepository : BaseRepository<Rol>
    {
        public RolRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Rol, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuarios];
    }
}
