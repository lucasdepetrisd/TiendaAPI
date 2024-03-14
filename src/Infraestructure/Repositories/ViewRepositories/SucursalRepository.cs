using Domain.Data;
using Domain.Models.Admin;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.ViewRepositories
{
    internal class SucursalRepository : ViewRepository<Sucursal>
    {
        public SucursalRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Sucursal, object>>[] NavigationPropertiesToLoad
        => [a => a.Tienda, a => a.Empleados, a => a.PuntosDeVentas];
    }
}
