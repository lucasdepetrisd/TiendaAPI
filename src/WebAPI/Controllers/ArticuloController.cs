using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public virtual async Task<ActionResult<ArticuloDTO>> GetByCodigoAsync(
            [Required][StringLength(maximumLength: 30, MinimumLength = 3)] string codigo)
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
