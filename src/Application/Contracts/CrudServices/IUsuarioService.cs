using Application.DTOs;
using Domain.Models;

namespace Application.Contracts.CrudServices
{
    public interface IUsuarioService : ICrudService<CreateUsuarioDTO, UsuarioDTO>
    {
    }
}