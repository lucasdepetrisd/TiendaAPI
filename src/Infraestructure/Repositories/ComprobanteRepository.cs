using Domain.Models;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    internal class ComprobanteRepository : BaseRepository<Comprobante>
    {
        public ComprobanteRepository(TiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Comprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
