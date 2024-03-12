using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IColorService : ICrudService<CreateColorDTO, ColorDTO>
    {
    }
}