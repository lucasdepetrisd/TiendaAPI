using Domain.Data;
using Domain.Models.Ventas;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.CrudRepositories
{
    internal class PagoRepository : CrudRepository<Pago>
    {
        public PagoRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Pago, object>>[] NavigationPropertiesToLoad
        => [a => a.Venta];
    }
}
