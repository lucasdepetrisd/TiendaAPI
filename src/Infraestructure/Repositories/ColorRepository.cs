using Domain.Data;
using Domain.Models;

namespace Infraestructure.Repositories
{
    internal class ColorRepository : BaseRepository<Color>
    {
        public ColorRepository(ITiendaContext context)
            : base(context)
        {
        }
    }
}
