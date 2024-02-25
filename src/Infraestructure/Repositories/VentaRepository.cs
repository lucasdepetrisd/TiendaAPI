using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class VentaRepository : BaseRepository<Venta>
    {
        public VentaRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Venta, object>>[] NavigationPropertiesToLoad
        => [v => v.TipoDeComprobante!, v => v.Cliente!, v => v.PuntoDeVenta!, v => v.Usuario!];
    }
}
