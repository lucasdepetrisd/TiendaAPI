using Application.DTOs;

namespace Application.Contracts.CrudServices
{
    public interface IRolService : ICrudService<CreateRolDTO, RolDTO>
    {
    }
}