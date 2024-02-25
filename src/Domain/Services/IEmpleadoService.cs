using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface IEmpleadoService : IBaseService<CreateEmpleadoDTO, EmpleadoDTO>
    {
    }
}