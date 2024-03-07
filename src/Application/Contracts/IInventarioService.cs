using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IInventarioService : IBaseService<CreateInventarioDTO, InventarioDTO>
    {
    }
}