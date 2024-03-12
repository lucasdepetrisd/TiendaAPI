using Application.DTOs;

namespace Application.Contracts
{
    public interface IArticuloService : ICrudService<CreateArticuloDTO, ArticuloDTO>
    {
        Task<ArticuloDTO?> GetByCodigoAsync(string codigo);
    }
}