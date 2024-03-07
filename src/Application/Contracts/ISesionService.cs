using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface ISesionService : IBaseService<CreateSesionDTO, SesionDTO>
    {
    }
}