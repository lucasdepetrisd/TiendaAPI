using Application.DTOs.Admin;

namespace Application.Contracts.CrudServices
{
    public interface IRolService : ICrudService<CreateRolDTO, RolDTO>
    {
    }
}