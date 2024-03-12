using Domain.Data;
using Domain.Models;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class InventarioRepository : CrudRepository<Inventario>
    {
        public InventarioRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Inventario, object>>[] NavigationPropertiesToLoad
            =>
        [
            a => a.Articulo,
            a => a.Articulo.Marca!,
            a => a.Articulo.TipoTalle!,
            a => a.Articulo.Categoria!,
            a => a.Sucursal,
            a => a.Color!,
            a => a.Talle!
        ];
    }
}
