using Application.DTOs;

namespace Application.Contracts.CrudServices
{
    public interface IEmpleadoService : ICrudService<CreateEmpleadoDTO, EmpleadoDTO>
    {
    }
}