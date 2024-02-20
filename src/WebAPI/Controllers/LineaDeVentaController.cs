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
    public class LineaDeVentaController : BaseController<LineaDeVenta, LineaDeVentaDTO, CreateLineaDeVentaDTO>
    {
        public LineaDeVentaController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /*protected override Expression<Func<LineaDeVenta, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
