using Application.DTOs.Admin.Articulo;

namespace Application.Contracts.CrudServices
{
    public interface IInventarioService : ICrudService<CreateInventarioDTO, InventarioDTO>
    {
    }
}