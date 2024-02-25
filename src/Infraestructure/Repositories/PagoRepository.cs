using Domain.Models;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    internal class PagoRepository : BaseRepository<Pago>
    {
        public PagoRepository(TiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Pago, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
