using Domain.Data;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Usuario, object>>[] NavigationPropertiesToLoad
        => [a => a.Empleado!, a => a.Rol!, a => a.Sesiones!];

        public async Task<Usuario?> GetByUsernameAsync(string nombreUsuario)
        {
            var query = _tiendaContext.Usuario.AsQueryable();

            query = query.Where(a => a.NombreUsuario == nombreUsuario);

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            return await query.SingleOrDefaultAsync();
        }
    }
}
