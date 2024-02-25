using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class SesionRepository : BaseRepository<Sesion>
    {
        public SesionRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Sesion, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuario, a => a.PuntoDeVenta];
    }
}
