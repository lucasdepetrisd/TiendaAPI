using Domain.Data;
using Domain.Models.Admin;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class EmpleadoRepository : CrudRepository<Empleado>
    {
        public EmpleadoRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Empleado, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursal!, a => a.Usuario!];
    }
}
