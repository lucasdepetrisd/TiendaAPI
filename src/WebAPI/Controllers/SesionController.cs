using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CerrarSesion([FromQuery] int sesionId)
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

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required int PuntoDeVentaId { get; set; }
    }
}
