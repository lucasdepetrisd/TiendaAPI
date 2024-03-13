using Application.DTOs;
using Domain.Models;

namespace Application.Contracts.CrudServices
{
    public interface IColorService : ICrudService<CreateColorDTO, ColorDTO>
    {
    }
}