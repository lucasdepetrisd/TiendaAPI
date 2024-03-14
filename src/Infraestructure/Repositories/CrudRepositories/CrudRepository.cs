using Domain.Data;
using Domain.Repositories;
using Infraestructure.Repositories.ViewRepositories;
using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Repositories
{
    internal abstract class CrudRepository<TEntity> : ViewRepository<TEntity>, ICrudRepository<TEntity>
        where TEntity : class
    {
        protected CrudRepository(ITiendaContext tiendaContext) : base(tiendaContext)
        {
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _tiendaContext.Set<TEntity>().Add(entity);
            await _tiendaContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _tiendaContext.Set<TEntity>().Update(entity);
            await _tiendaContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                var keyProperty = typeof(TEntity).GetProperties()
                    .FirstOrDefault(prop => prop.IsDefined(typeof(KeyAttribute), false));

                if (keyProperty != null)
                {
                    var keyValue = Convert.ChangeType(id, keyProperty.PropertyType);
                    keyProperty.SetValue(entity, keyValue);

                    _tiendaContext.Set<TEntity>().Remove(entity);
                    await _tiendaContext.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Primary key not found for the entity.");
                }
            }

            /*_tiendaContext.Set<TEntity>().Remove(entity);
            await _tiendaContext.SaveChangesAsync();*/
        }
    }
}