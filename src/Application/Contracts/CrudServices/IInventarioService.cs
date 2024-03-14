using Application.DTOs;

namespace Application.Contracts.CrudServices
{
    public interface IInventarioService : ICrudService<CreateInventarioDTO, InventarioDTO>
    {
    }
}