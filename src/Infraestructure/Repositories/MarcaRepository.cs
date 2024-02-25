using Domain.Models;
using Infraestructure.Data;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    internal class MarcaRepository : BaseRepository<Marca>
    {
        public MarcaRepository(TiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Marca, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];
    }
}
