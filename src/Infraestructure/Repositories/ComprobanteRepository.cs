using Domain.Data;
using Domain.Models;

namespace Infraestructure.Repositories
{
    internal class ComprobanteRepository : BaseRepository<Comprobante>
    {
        public ComprobanteRepository(ITiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Comprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
