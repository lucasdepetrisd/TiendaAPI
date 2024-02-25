using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class InventarioRepository : BaseRepository<Inventario>
    {
        public InventarioRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Inventario, object>>[] NavigationPropertiesToLoad
            => new Expression<Func<Inventario, object>>[]
        {
            a => a.Articulo,
            a => a.Articulo.Marca!,
            a => a.Articulo.TipoTalle!,
            a => a.Articulo.Categoria!,
            a => a.Sucursal,
            a => a.Color!,
            a => a.Talle!
        };
    }
}
