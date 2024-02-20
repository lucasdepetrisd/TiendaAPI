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
    public class RolController : BaseController<Rol, RolDTO, CreateRolDTO>
    {
        public RolController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Rol, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuarios];
    }
}
