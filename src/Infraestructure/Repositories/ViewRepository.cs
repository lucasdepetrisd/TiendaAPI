using Domain.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Infraestructure.Repositories
{
    internal abstract class ViewRepository<TEntity> : IViewRepository<TEntity>
        where TEntity : class
    {
        protected readonly ITiendaContext _tiendaContext;
        private readonly PropertyInfo _idProperty;

        protected ViewRepository(ITiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
            _idProperty = typeof(TEntity).GetProperty($"Id{typeof(TEntity).Name}")
                    ?? throw new InvalidOperationException($"Entity {typeof(TEntity).Name} does not have an ID property.");
        }

        protected virtual Expression<Func<TEntity, bool>> PrimaryKeyPredicate(int id)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var member = Expression.PropertyOrField(parameter, _idProperty.Name);
            var constant = Expression.Constant(id);
            var body = Expression.Equal(member, constant);

            return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        }

        protected virtual Expression<Func<TEntity, object>>[] NavigationPropertiesToLoad => [];

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var query = _tiendaContext.Set<TEntity>().AsQueryable();

            query = query.Where(PrimaryKeyPredicate(id));

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            return await query.SingleOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var query = _tiendaContext.Set<TEntity>().AsQueryable();

            foreach (var property in NavigationPropertiesToLoad)
                query = query.Include(property);

            return await query.ToListAsync();
        }
    }
}