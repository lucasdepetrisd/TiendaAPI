using Domain.DTOs;

namespace Domain.Services
{
    public interface IArticuloService : IBaseService<CreateArticuloDTO, ArticuloDTO>
    {
        Task<ArticuloDTO?> GetByCodigoAsync(string codigo);
    }
}