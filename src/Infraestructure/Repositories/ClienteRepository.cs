using Domain.Data;
using Domain.Models;

namespace Infraestructure.Repositories
{
    internal class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(ITiendaContext context)
            : base(context)
        {
        }

        /*protected override Expression<Func<Cliente, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
