using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> IniciarVentaAsync([FromQuery] IniciarVentaRequest iniciarVentaRequest)
        {
            try
            {
                /*if (usuarioId <= 0 || puntoDeVentaId <= 0)
                {
                    return BadRequest("Invalid usuarioId or puntoDeVentaId.");
                }*/

                var venta = await _ventaService.IniciarVenta(iniciarVentaRequest.UsuarioId, iniciarVentaRequest.PuntoDeVentaId);

                return Ok(venta);
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error iniciando la Venta. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }

        [HttpPost("LineaDeVenta/Agregar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<ActionResult<LineaDeVentaDTO>> AgregarLineaDeVenta(
            [FromQuery] AgregarLineaDeVentaRequest agregarLineaDeVentaRequest)
        {
            try
            {
                if (agregarLineaDeVentaRequest.Cantidad <= 0)
                {
                    return BadRequest("Cantidad inválida. Ingrese una cantidad mayor a 0.");
                }

                var lineaDeVentaDTO = await _ventaService.AgregarLineaDeVenta(
                    agregarLineaDeVentaRequest.VentaId,
                    agregarLineaDeVentaRequest.Cantidad,
                    agregarLineaDeVentaRequest.InventarioId);

                return Ok(lineaDeVentaDTO);
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al añadir una LineaDeVenta a la Venta. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }
    }

    public record IniciarVentaRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "UsuarioId debe ser mayor que cero.")]
        public int UsuarioId { get; init; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "PuntoDeVentaId debe ser mayor que cero.")]
        public int PuntoDeVentaId { get; init; }
    }

    public record AgregarLineaDeVentaRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "VentaId debe ser mayor que cero.")]
        public int VentaId { get; init; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Cantidad debe ser mayor que cero.")]
        public int Cantidad { get; init; }

        [Required]
        public int InventarioId { get; init; }
    }
}
