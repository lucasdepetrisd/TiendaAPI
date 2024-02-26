using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class PuntoDeVentaRepository : BaseRepository<PuntoDeVenta>
    {
        public PuntoDeVentaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<PuntoDeVenta, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursal, a => a.Sesiones, a => a.Ventas];
    }
}
