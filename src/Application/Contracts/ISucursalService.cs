using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface ISucursalService : IBaseService<CreateSucursalDTO, SucursalDTO>
    {
    }
}