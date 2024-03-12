using Domain.Data;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Usuario, object>>[] NavigationPropertiesToLoad
        => [a => a.Empleado!, a => a.Rol!, a => a.Sesiones!];

        public override async Task<Usuario?> GetByIdAsync(int id)
        {
            var query = _tiendaContext.Usuario.AsQueryable();

            query = query.Where(a => a.IdUsuario == id);

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            query = query.Include(u => u.Empleado)
                .ThenInclude(u => u.Sucursal);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<Usuario?> GetByUsernameAsync(string nombreUsuario)
        {
            var query = _tiendaContext.Usuario.AsQueryable();

            query = query.Where(a => a.NombreUsuario == nombreUsuario);

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            query = query.Include(u => u.Empleado)
                .ThenInclude(u => u.Sucursal);

            return await query.SingleOrDefaultAsync();
        }
    }
}
