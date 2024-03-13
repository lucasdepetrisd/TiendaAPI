using Domain.Data;
using Domain.Models;

namespace Infraestructure.Repositories.CrudRepositories
{
    internal class ComprobanteRepository : CrudRepository<Comprobante>
    {
        public ComprobanteRepository(ITiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Comprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
