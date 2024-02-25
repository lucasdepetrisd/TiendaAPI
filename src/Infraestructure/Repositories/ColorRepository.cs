using Domain.Models;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    internal class ColorRepository : BaseRepository<Color>
    {
        public ColorRepository(TiendaContext context)
            : base(context)
        {
        }
    }
}
