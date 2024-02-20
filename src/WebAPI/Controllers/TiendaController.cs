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
    public class TiendaController : BaseController<Tienda, TiendaDTO, TiendaDTO>
    {
        public TiendaController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Tienda, object>>[] NavigationPropertiesToLoad
        => [a => a.Sucursales];

        [NonAction]
        [HttpPost]
        public override Task<ActionResult<TiendaDTO>> Post(TiendaDTO tiendaDTO)
        {
            // Do nothing or throw an exception to indicate it's not implemented
            throw new NotImplementedException("Post method is not supported for TiendaController.");
        }

        [NonAction]
        [HttpDelete]
        public override Task<IActionResult> Delete(int id)
        {
            // Do nothing or throw an exception to indicate it's not implemented
            throw new NotImplementedException("Delete method is not supported for TiendaController.");
        }
    }
}
