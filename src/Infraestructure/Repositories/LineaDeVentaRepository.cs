using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class LineaDeVentaRepository : BaseRepository<LineaDeVenta>
    {
        public LineaDeVentaRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<LineaDeVenta, object>>[] NavigationPropertiesToLoad
        => [a => a.Inventario];
    }
}
