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

        public VentaController(IVentaService ventaService)
            : base(ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost("Iniciar")]
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

        [HttpPost("LineaDeVenta/Agregar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> AgregarLineaDeVenta(
            [FromQuery] AgregarLineaDeVentaRequest request)
        {
            try
            {
                var lineaDeVentaDTO = await _ventaService.AgregarLineaDeVenta(
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

        [HttpDelete("LineaDeVenta/Quitar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> QuitarLineaDeVenta(
            [FromQuery] QuitarLineaDeVentaRequest request)
        {
            try
            {
                var ventaDTO = await _ventaService.QuitarLineaDeVenta(
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

        [HttpPost("LineaDeVenta/ActualizarMonto")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> ActualizarMonto(
           [FromQuery][Required][Range(0, int.MaxValue, ErrorMessage = "VentaId debe ser igual o mayor que cero.")] int idVenta)
        {
            try
            {
                var ventaDTO = await _ventaService.ActualizarMonto(idVenta);

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

        [HttpPut("Cancelar")]
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

        [NonAction]
        [HttpPost("Finalizar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> FinalizarVenta([FromBody] FinalizarVentaRequest request)
        {
            try
            {
                //await _ventaService.FinalizarVenta(request.VentaId, request.MontoPago, request.EsTarjeta, request.DatosTarjeta);

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
        public int VentaId { get; init; }
        public decimal MontoPago { get; init; }
        public bool EsTarjeta { get; init; }
        public TarjetaDTORequest? DatosTarjeta { get; init; } // DTO que representa los datos de la tarjeta, si corresponde
    }

    public record TarjetaDTORequest
    {
        public required string NumeroTarjeta { get; set; }
        public required string Titular { get; set; }
        public required string FechaExpiracion { get; set; }
        public required string CVV { get; set; }
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
