using Domain.Data;
using Domain.Models.Articulo;

namespace Infraestructure.Repositories
{
    internal class ColorRepository : CrudRepository<Color>
    {
        public ColorRepository(ITiendaContext context)
            : base(context)
        {
        }
    }
}
