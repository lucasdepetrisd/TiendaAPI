using Application.Contracts;
using Application.DTOs;
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
        private readonly ILineaDeVentaService _lineaDeVentaService;

        public VentaController(IVentaService ventaService, ILineaDeVentaService lineaDeVentaService)
            : base(ventaService)
        {
            _ventaService = ventaService;
            _lineaDeVentaService = lineaDeVentaService;
        }

        [HttpPost("iniciar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> IniciarVenta([FromQuery] IniciarVentaRequest request)
        {
            try
            {
                var venta = await _ventaService.IniciarVenta(
                    request.UsuarioId,
                    request.PuntoDeVentaId);

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

        [HttpPost("lineadeventa/agregar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> AgregarLineaDeVenta(
            [FromQuery] AgregarLineaDeVentaRequest request)
        {
            try
            {
                var lineaDeVentaDTO = await _lineaDeVentaService.AgregarLineaDeVenta(
                    request.VentaId,
                    request.Cantidad,
                    request.InventarioId);

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

        [HttpDelete("lineadeventa/quitar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> QuitarLineaDeVenta(
            [FromQuery] QuitarLineaDeVentaRequest request)
        {
            try
            {
                var ventaDTO = await _lineaDeVentaService.QuitarLineaDeVenta(
                    request.VentaId,
                    request.LineaDeVentaId);

                return Ok(ventaDTO);
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

        [HttpPost("lineadeventa/actualizarmonto")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> ActualizarMonto(
           [FromQuery][Required][Range(0, int.MaxValue, ErrorMessage = "VentaId debe ser igual o mayor que cero.")] int idVenta)
        {
            try
            {
                var ventaDTO = await _ventaService.ActualizarMonto(idVenta);

                return Ok(ventaDTO.Monto);
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

        [HttpPut("cancelar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> CancelarVentaAsync([FromQuery] int idVenta)
        {
            try
            {
                VentaDTO ventaCanceladaDTO = await _ventaService.CancelarVenta(idVenta);

                return Ok(ventaCanceladaDTO);
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al cancelar la venta. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }

        [HttpPost("finalizar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> FinalizarVenta([FromBody] FinalizarVentaRequest request)
        {
            try
            {
                await _ventaService.FinalizarVenta(request.VentaId, request.EsTarjeta, request.DatosTarjeta);

                return Ok($"Venta con ID {request.VentaId} finalizada correctamente.");
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al finalizar la venta. Error: {errorMessage}");
            }
            catch (Exception ex)
            {
                string? errorMessage = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }
        }
    }

    public record FinalizarVentaRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "VentaId debe ser mayor igual o que cero.")]
        public int VentaId { get; init; }
        [Required]
        public bool EsTarjeta { get; init; }
        public TarjetaDTO? DatosTarjeta { get; init; }
    }

    public record IniciarVentaRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "UsuarioId debe ser mayor igual o que cero.")]
        public int UsuarioId { get; init; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "PuntoDeVentaId debe ser igual o mayor que cero.")]
        public int PuntoDeVentaId { get; init; }
    }

    public record AgregarLineaDeVentaRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "VentaId debe ser igual o mayor que cero.")]
        public int VentaId { get; init; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe ser mayor que cero.")]
        public int Cantidad { get; init; }

        [Required]
        public int InventarioId { get; init; }
    }

    public record QuitarLineaDeVentaRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "VentaId debe ser igual o mayor que cero.")]
        public int VentaId { get; init; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "LineaDeVentaId debe ser igual o mayor que cero.")]
        public int LineaDeVentaId { get; init; }
    }
}
