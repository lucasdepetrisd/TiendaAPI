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
    public class EmpleadoController : BaseController<Empleado, EmpleadoDTO, CreateEmpleadoDTO>
    {
        public EmpleadoController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Empleado, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursal, a => a.Usuario];
    }
}
