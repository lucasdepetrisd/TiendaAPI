using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionTributariaController : CrudController<CondicionTributariaDTO, CondicionTributariaDTO>
    {
        private readonly ICondicionTributariaService _condicionTributariaService;

        public CondicionTributariaController(ICondicionTributariaService condicionTributariaService)
            : base(condicionTributariaService)
        {
            _condicionTributariaService = condicionTributariaService;
        }

        [NonAction]
        [HttpPost]
        public override Task<ActionResult<CondicionTributariaDTO>> Post(CondicionTributariaDTO condicionTributariaDTO)
        {
            throw new NotImplementedException("Post method is not supported for CondicionTributariaController.");
        }

        [NonAction]
        [HttpDelete]
        public override Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException("Delete method is not supported for CondicionTributariaController.");
        }
    }
}
