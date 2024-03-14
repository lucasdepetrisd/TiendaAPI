using Application.DTOs.Admin.Articulo;

namespace Application.Contracts.CrudServices
{
    public interface ICategoriaService : ICrudService<CreateCategoriaDTO, CategoriaDTO>
    {
    }
}