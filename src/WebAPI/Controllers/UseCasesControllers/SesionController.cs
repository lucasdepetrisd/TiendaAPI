using Application.Contracts.UseCasesServices;
using Application.DTOs.Admin;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using WebAPI.Controllers.ViewControllers;

namespace WebAPI.Controllers.UseCasesControllers
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
            try
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
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocurrió un error iniciando sesión. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }

        [HttpPut("cerrarsesion")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> CerrarSesion(
            [FromQuery][Range(0, int.MaxValue, ErrorMessage = "sesionId debe ser igual o mayor a cero.")][Required] int sesionId)
        {
            try
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
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocurrió un error cerrando la sesión. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
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
