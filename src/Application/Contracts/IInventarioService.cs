using Application.DTOs;

namespace Application.Contracts
{
    public interface IInventarioService : ICrudService<CreateInventarioDTO, InventarioDTO>
    {
    }
}