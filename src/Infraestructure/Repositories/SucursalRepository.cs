using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class SucursalRepository : BaseRepository<Sucursal>
    {
        public SucursalRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Sucursal, object>>[] NavigationPropertiesToLoad
        => [a => a.Tienda, a => a.Empleados, a => a.PuntosDeVentas];
    }
}
