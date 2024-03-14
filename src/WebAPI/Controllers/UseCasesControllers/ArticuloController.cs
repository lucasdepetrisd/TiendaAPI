using Application.Contracts.UseCasesServices;
using Application.DTOs.Admin.Articulo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.Controllers.CrudControllers;

namespace WebAPI.Controllers.UseCasesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : CrudController<CreateArticuloDTO, ArticuloDTO>
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
            : base(articuloService, articuloService)
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
