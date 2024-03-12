using Application.DTOs;

namespace Application.Contracts
{
    public interface IRolService : ICrudService<CreateRolDTO, RolDTO>
    {
    }
}