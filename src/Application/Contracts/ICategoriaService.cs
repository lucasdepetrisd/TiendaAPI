using Application.DTOs;

namespace Application.Contracts
{
    public interface ICategoriaService : ICrudService<CreateCategoriaDTO, CategoriaDTO>
    {
    }
}