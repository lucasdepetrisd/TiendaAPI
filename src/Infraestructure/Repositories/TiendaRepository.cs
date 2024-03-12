using Domain.Data;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class TiendaRepository : ViewRepository<Tienda>, ITiendaRepository
    {
        public TiendaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Tienda, object>>[] NavigationPropertiesToLoad
        => [t => t.Sucursales, t => t.CondicionTributaria];

        public async Task<Tienda?> GetFirstOrDefault()
        {
            var query = _tiendaContext.Tienda.AsQueryable();

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            return await query.FirstOrDefaultAsync();
        }
    }
}
