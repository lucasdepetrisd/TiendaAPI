namespace Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
    }
}
