using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : BaseService<Usuario, CreateUsuarioDTO, UsuarioDTO>, IUsuarioService
    {
        public UsuarioService(IRepository<Usuario> usuarioRepository, IMapper mapper) : base(usuarioRepository, mapper)
        {
        }
    }
}
