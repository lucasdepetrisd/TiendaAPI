using Domain.Models;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    internal class LineaDeVentaRepository : BaseRepository<LineaDeVenta>
    {
        public LineaDeVentaRepository(TiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<LineaDeVenta, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
