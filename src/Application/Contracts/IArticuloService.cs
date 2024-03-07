using Application.DTOs;

namespace Application.Contracts
{
    public interface IArticuloService : IBaseService<CreateArticuloDTO, ArticuloDTO>
    {
        Task<ArticuloDTO?> GetByCodigoAsync(string codigo);
    }
}