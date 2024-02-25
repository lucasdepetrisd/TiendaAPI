using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface IColorService : IBaseService<CreateColorDTO, ColorDTO>
    {
    }
}