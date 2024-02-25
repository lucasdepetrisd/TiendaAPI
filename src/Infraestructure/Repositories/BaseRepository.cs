using Domain.Models;
using Domain.Repositories;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

internal abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly TiendaContext TiendaContextDb;
    private readonly PropertyInfo _idProperty;

    protected BaseRepository(TiendaContext tiendaContextDb)
    {
        TiendaContextDb = tiendaContextDb;
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

    public virtual Task<TEntity?> GetByIdAsync(int id)
    {
        var query = TiendaContextDb.Set<TEntity>().AsQueryable();

        query = query.Where(PrimaryKeyPredicate(id));

        foreach (var property in NavigationPropertiesToLoad)
            query = query.Include(property);

        return query.SingleOrDefaultAsync();
    }

    public virtual Task<List<TEntity>> GetAllAsync()
    {
        var query = TiendaContextDb.Set<TEntity>().AsQueryable();

        foreach (var property in NavigationPropertiesToLoad)
            query = query.Include(property);

        return query.ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        TiendaContextDb.Set<TEntity>().Add(entity);
        await TiendaContextDb.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        TiendaContextDb.Set<TEntity>().Update(entity);
        await TiendaContextDb.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        TiendaContextDb.Set<TEntity>().Remove(entity);
        await TiendaContextDb.SaveChangesAsync();
    }
}