using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : BaseController<CreateSesionDTO, SesionDTO>
    {
        private readonly ISesionService _sesionService;
        private readonly IAuthenticationService _authenticationService;

        public SesionController(ISesionService sesionService, IAuthenticationService authenticationService)
            : base(sesionService)
        {
            _sesionService = sesionService;
            _authenticationService = authenticationService;
        }

        [HttpPost("IniciarSesion")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<ActionResult<SesionDTO>> IniciarSesion([FromQuery] LoginRequest request)
        {
            var sesion = await _authenticationService.IniciarSesion(request.PuntoDeVentaId, request.Username, request.Password);
            if (sesion != null)
            {
                return Ok(sesion);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("CerrarSesion")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> CerrarSesion(
            [FromQuery][Range(0, int.MaxValue, ErrorMessage = "sesionId debe ser mayor que cero.")][Required] int sesionId)
        {
            var sesion = await _authenticationService.CerrarSesion(sesionId);

            if (sesion != null)
            {
                return Ok("Sesión cerrada correctamente.");
            }
            else
            {
                return NotFound("No se encontró la sesión especificada.");
            }
        }
    }

    public record LoginRequest
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public required string Username { get; init; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public required string Password { get; init; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "PuntoDeVentaId debe ser mayor que cero.")]
        public required int PuntoDeVentaId { get; init; }
    }
}
