using Application.DTOs.Admin;

namespace Application.Contracts.CrudServices
{
    public interface IEmpleadoService : ICrudService<CreateEmpleadoDTO, EmpleadoDTO>
    {
    }
}