using Domain.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IEmpleadoService : IBaseService<CreateEmpleadoDTO, EmpleadoDTO>
    {
    }
}