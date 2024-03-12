using AutoMapper;
using Application.DTOs;
using Domain.Models;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Services
{
    public class UsuarioService : CrudService<Usuario, CreateUsuarioDTO, UsuarioDTO>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) : base(usuarioRepository, mapper)
        {
        }
    }
}
