using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : BaseController<CreateArticuloDTO, ArticuloDTO>
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
            : base(articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet("codigo/{codigo}")]

        [ApiExplorerSettings(GroupName = "UseCases")]
        public virtual async Task<ActionResult<ArticuloDTO>> GetByCodigoAsync(string codigo)
        {
            var entityDTO = await _articuloService.GetByCodigoAsync(codigo);

            if (entityDTO == null)
            {
                return NotFound();
            }

            return Ok(entityDTO);
        }
    }
}
