using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class SucursalRepository : BaseRepository<Sucursal>
    {
        public SucursalRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Sucursal, object>>[] NavigationPropertiesToLoad
        => [a => a.Tienda, a => a.Empleados, a => a.PuntosDeVentas];
    }
}
