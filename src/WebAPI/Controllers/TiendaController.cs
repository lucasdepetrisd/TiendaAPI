using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : BaseController<TiendaDTO, TiendaDTO>
    {
        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
            : base(tiendaService)
        {
            _tiendaService = tiendaService;
        }

        [NonAction]
        [HttpPost]
        public override Task<ActionResult<TiendaDTO>> Post(TiendaDTO tiendaDTO)
        {
            throw new NotImplementedException("Post method is not supported for TiendaController.");
        }

        [NonAction]
        [HttpDelete]
        public override Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException("Delete method is not supported for TiendaController.");
        }
    }
}
