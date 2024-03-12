using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ViewController<SesionDTO>
    {
        private readonly IAutenticacionUsuarioService _authenticationService;

        public SesionController(ISesionService sesionService, IAutenticacionUsuarioService authenticationService)
            : base(sesionService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("iniciarsesion")]
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

        [HttpPut("cerrarsesion")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> CerrarSesion(
            [FromQuery][Range(0, int.MaxValue, ErrorMessage = "sesionId debe ser igual o mayor a cero.")][Required] int sesionId)
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
        [Range(0, int.MaxValue, ErrorMessage = "PuntoDeVentaId debe ser igual o mayor a cero.")]
        public required int PuntoDeVentaId { get; init; }
    }
}
