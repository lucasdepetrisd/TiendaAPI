using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Usuario, object>>[] NavigationPropertiesToLoad
        => [a => a.Empleado!, a => a.Rol!];
    }
}
