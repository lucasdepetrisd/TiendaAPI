namespace Domain.Repositories
{
    public interface IViewRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
    }
}
