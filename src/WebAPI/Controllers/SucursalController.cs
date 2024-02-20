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
    public class SucursalController : BaseController<Sucursal, SucursalDTO, CreateSucursalDTO>
    {
        public SucursalController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Sucursal, object>>[] NavigationPropertiesToLoad
        => [a => a.Tienda, a => a.Empleados, a => a.PuntosDeVentas];
    }
}
