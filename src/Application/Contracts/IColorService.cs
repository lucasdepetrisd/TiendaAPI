using Domain.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IColorService : IBaseService<CreateColorDTO, ColorDTO>
    {
    }
}