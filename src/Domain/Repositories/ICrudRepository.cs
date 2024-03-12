namespace Domain.Repositories
{
    public interface ICrudRepository<TEntity> : IViewRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
    }
}
