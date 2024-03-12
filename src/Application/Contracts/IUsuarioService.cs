using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUsuarioService : ICrudService<CreateUsuarioDTO, UsuarioDTO>
    {
    }
}