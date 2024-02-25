using Domain.Models;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    internal class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(TiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Cliente, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
