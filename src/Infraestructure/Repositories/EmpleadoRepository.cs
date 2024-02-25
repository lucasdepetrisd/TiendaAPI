using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class EmpleadoRepository : BaseRepository<Empleado>
    {
        public EmpleadoRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Empleado, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursal!, a => a.Usuario!];
    }
}
