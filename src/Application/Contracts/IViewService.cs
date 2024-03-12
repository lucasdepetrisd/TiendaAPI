namespace Application.Contracts
{
    public interface IViewService<TResponseDTO>
    {
        Task<List<TResponseDTO>> GetAllAsync();
        Task<TResponseDTO?> GetByIdAsync(int id);
    }
}
