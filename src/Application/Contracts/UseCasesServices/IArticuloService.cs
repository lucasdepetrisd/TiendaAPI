using Application.Contracts.CrudServices;
using Application.DTOs;

namespace Application.Contracts.UseCasesServices
{
    public interface IArticuloService : ICrudService<CreateArticuloDTO, ArticuloDTO>
    {
        Task<ArticuloDTO?> GetByCodigoAsync(string codigo);
    }
}