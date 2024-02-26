using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class LineaDeVentaRepository : BaseRepository<LineaDeVenta>
    {
        public LineaDeVentaRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<LineaDeVenta, object>>[] NavigationPropertiesToLoad
        => [a => a.Inventario];
    }
}
