using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.CrudRepositories
{
    internal class SesionRepository : CrudRepository<Sesion>
    {
        public SesionRepository(ITiendaContext context)
            : base(context)
        {
        }

        protected override Expression<Func<Sesion, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuario, a => a.PuntoDeVenta];

        public override async Task AddAsync(Sesion sesion)
        {
            var existingEntity = _tiendaContext.Set<Sesion>().Find(sesion.IdSesion);
            if (existingEntity != null)
            {
                _tiendaContext.Set<Sesion>().Entry(existingEntity).State = EntityState.Detached;
            }

            _tiendaContext.Set<Sesion>().Add(sesion);
            await _tiendaContext.SaveChangesAsync();
        }
    }
}
