using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class VentaRepository : CrudRepository<Venta>
    {
        public VentaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Venta, object>>[] NavigationPropertiesToLoad
            =>
            [
                v => v.TipoDeComprobante!,
                v => v.Cliente!,
                v => v.PuntoDeVenta!,
                v => v.Usuario!,
                v => v.LineasDeVentas
            ];

        public override async Task<Venta?> GetByIdAsync(int id)
        {
            var query = _tiendaContext.Set<Venta>().AsQueryable();

            query = query
                .Include(v => v.TipoDeComprobante)
                .Include(v => v.Cliente)
                    .ThenInclude(c => c.CondicionTributaria)
                .Include(v => v.PuntoDeVenta)
                .Include(v => v.Usuario)
                .Include(v => v.LineasDeVentas)
                .Where(v => v.IdVenta == id);

            return await query.SingleOrDefaultAsync();
        }

        public override async Task AddAsync(Venta venta)
        {
            if (venta.TipoDeComprobante != null)
            {
                // Chequeo si existe algun tipo de comprobante con esa misma combinacion Emisor - Receptor
                var existingTipoDeComprobante = await _tiendaContext.TipoDeComprobante
                    .FirstOrDefaultAsync(tc =>
                        tc.IdCondicionTributariaEmisor == venta.TipoDeComprobante.CondicionTributariaEmisor.IdCondicionTributaria &&
                        tc.IdCondicionTributariaReceptor == venta.TipoDeComprobante.CondicionTributariaReceptor.IdCondicionTributaria);

                if (existingTipoDeComprobante != null)
                {
                    // Si encuentra alguno utiliza ese agregandolo a la venta
                    venta.TipoDeComprobante = existingTipoDeComprobante;
                }
                /*else
                {
                    // Si no encuentra ninguno utiliza esa combinación existente
                    _tiendaContext.TipoDeComprobante.Add(venta.TipoDeComprobante);
                }*/
            }

            _tiendaContext.Set<Venta>().Add(venta);
            await _tiendaContext.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Venta venta)
        {
            _tiendaContext.Set<Venta>().Update(venta);
            await _tiendaContext.SaveChangesAsync();
        }
    }
}
