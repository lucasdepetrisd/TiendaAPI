using Domain.Data;
using Domain.Models.Ventas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class LineaDeVentaRepository : CrudRepository<LineaDeVenta>
    {
        public LineaDeVentaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<LineaDeVenta, object>>[] NavigationPropertiesToLoad
        => [ldv => ldv.Inventario, ldv => ldv.Venta];

        public override async Task<LineaDeVenta?> GetByIdAsync(int id)
        {
            var query = _tiendaContext.LineaDeVenta.AsQueryable();

            query = query
                .Include(ldv => ldv.Venta)
                .Include(ldv => ldv.Inventario)
                    .ThenInclude(i => i.Talle)
                .Include(ldv => ldv.Inventario)
                    .ThenInclude(i => i.Articulo).ThenInclude(i => i.TipoTalle)
                .Include(ldv => ldv.Inventario)
                    .ThenInclude(i => i.Articulo).ThenInclude(i => i.Marca)
                .Include(ldv => ldv.Inventario)
                    .ThenInclude(i => i.Articulo).ThenInclude(i => i.Categoria)
                .Include(ldv => ldv.Inventario)
                    .ThenInclude(i => i.Color)
                .Where(a => a.IdLineaDeVenta == id);

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            return await query.SingleOrDefaultAsync();
        }
    }
}
