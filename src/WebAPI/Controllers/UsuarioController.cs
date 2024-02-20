using Microsoft.AspNetCore.Mvc;
using Application.Data;
using AutoMapper;
using Domain.DTOs;
using System.Linq.Expressions;
using Domain.Models;
using WebAPI.Controllers;

namespace Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<Usuario, UsuarioDTO, CreateUsuarioDTO>
    {
        public UsuarioController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Usuario, object>>[] NavigationPropertiesToLoad
        => [a => a.Empleado, a => a.Rol];
    }
}
