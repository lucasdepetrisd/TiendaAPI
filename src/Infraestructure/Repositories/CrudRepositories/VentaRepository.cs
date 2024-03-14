using Domain.Data;
using Domain.Models.Ventas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.CrudRepositories
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
                    .ThenInclude(v => v.CondicionTributariaEmisor)
                .Include(v => v.TipoDeComprobante)
                    .ThenInclude(v => v.CondicionTributariaReceptor)
                .Include(v => v.Cliente)
                    .ThenInclude(c => c.CondicionTributaria)
                .Include(v => v.PuntoDeVenta)
                .Include(v => v.Usuario)
                .Include(v => v.LineasDeVentas)
                    .ThenInclude(c => c.Inventario)
                .Include(v => v.Pago)
                .Include(v => v.Comprobante)
                .Where(v => v.IdVenta == id);

            return await query.SingleOrDefaultAsync();
        }

        public override async Task AddAsync(Venta venta)
        {
            try
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
                }
            }
            catch (Exception)
            {
                throw new DbUpdateException("No se pudo identificar el emisor/receptor de la venta.");
            }

            _tiendaContext.Set<Venta>().Add(venta);
            await _tiendaContext.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Venta venta)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("No se pudo identificar el emisor/receptor de la venta.");
            }

            _tiendaContext.Set<Venta>().Update(venta);
            await _tiendaContext.SaveChangesAsync();
        }
    }
}
