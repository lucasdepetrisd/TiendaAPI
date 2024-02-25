using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface ICategoriaService : IBaseService<CreateCategoriaDTO, CategoriaDTO>
    {
    }
}