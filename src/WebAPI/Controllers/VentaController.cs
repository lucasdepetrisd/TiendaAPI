using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : BaseController<CreateVentaDTO, VentaDTO>
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
            : base(ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost("Iniciar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> IniciarVentaAsync([FromQuery] int usuarioId, [FromQuery] int puntoDeVentaId)
        {
            try
            {
                if (usuarioId <= 0 || puntoDeVentaId <= 0)
                {
                    return BadRequest("Invalid usuarioId or puntoDeVentaId.");
                }

                var venta = await _ventaService.IniciarVenta(usuarioId, puntoDeVentaId);

                return Ok(venta);
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating {typeof(VentaDTO).Name}. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }

        [HttpPost("LineaDeVenta/Agregar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<ActionResult<LineaDeVentaDTO>> AgregarLineaDeVenta([FromQuery] int ventaId, [FromQuery] int cantidad, [FromQuery] int inventarioId, [FromQuery] decimal porcentajeIVA)
        {
            try
            {
                if (ventaId <= 0 || inventarioId <= 0)
                {
                    return BadRequest("Invalid ventaId or inventarioId.");
                }
                else if (cantidad <= 0)
                {
                    return BadRequest("Invalid cantidad, select a cantidad higher than 0.");
                }

                var lineaDeVentaDTO = await _ventaService.AgregarLineaDeVenta(ventaId, cantidad, inventarioId, porcentajeIVA);

                return Ok(lineaDeVentaDTO);
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding {typeof(LineaDeVentaDTO).Name} to Venta. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }
    }
}
