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
    public class PuntoDeVentaController : BaseController<PuntoDeVenta, PuntoDeVentaDTO, CreatePuntoDeVentaDTO>
    {
        public PuntoDeVentaController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<PuntoDeVenta, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursal, a => a.Sesiones, a => a.Ventas];
    }
}
