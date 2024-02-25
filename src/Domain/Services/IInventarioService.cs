using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface IInventarioService : IBaseService<CreateInventarioDTO, InventarioDTO>
    {
    }
}