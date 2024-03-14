using Application.DTOs;

namespace Application.Contracts.CrudServices
{
    public interface ICategoriaService : ICrudService<CreateCategoriaDTO, CategoriaDTO>
    {
    }
}