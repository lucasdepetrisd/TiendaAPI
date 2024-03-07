using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUsuarioService : IBaseService<CreateUsuarioDTO, UsuarioDTO>
    {
    }
}