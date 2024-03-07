using Domain.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Infraestructure.Repositories;

internal abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly ITiendaContext _tiendaContext;
    private readonly PropertyInfo _idProperty;

    protected BaseRepository(ITiendaContext tiendaContext)
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

    protected virtual Expression<Func<TEntity, object>>[] NavigationPropertiesToLoad => Array.Empty<Expression<Func<TEntity, object>>>();

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