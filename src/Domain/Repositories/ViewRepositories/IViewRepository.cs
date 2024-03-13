namespace Domain.Repositories.ViewRepositories
{
    public interface IViewRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
    }
}
