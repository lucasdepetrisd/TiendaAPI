using Domain.Data;
using Domain.Models;

namespace Infraestructure.Repositories
{
    internal class PagoRepository : BaseRepository<Pago>
    {
        public PagoRepository(ITiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Pago, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
