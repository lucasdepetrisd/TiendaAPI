using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface ICategoriaService : IBaseService<CreateCategoriaDTO, CategoriaDTO>
    {
    }
}