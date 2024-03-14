using AutoMapper;
using Domain.Repositories;
using Application.Contracts.CrudServices;
using Application.DTOs.Admin;
using Domain.Models.Admin;

namespace Application.Services.CrudServices
{
    public class UsuarioService : CrudService<Usuario, CreateUsuarioDTO, UsuarioDTO>, IUsuarioService
    {
        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper) : base(usuarioRepository, mapper)
        {
        }
    }
}
