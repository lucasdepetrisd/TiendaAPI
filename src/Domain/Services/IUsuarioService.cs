using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface IUsuarioService : IBaseService<CreateUsuarioDTO, UsuarioDTO>
    {
    }
}