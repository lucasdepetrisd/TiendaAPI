using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ViewController<VentaDTO>
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
        public async Task<IActionResult> IniciarVenta([FromBody] IniciarVentaRequest request)
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

        [HttpPost("{ventaId}/lineadeventa/agregar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> AgregarLineaDeVenta(
            [Range(0, int.MaxValue)] int ventaId,
            [FromBody] AgregarLineaDeVentaRequest request)
        {
            if (ventaId < 0)
            {
                return BadRequest("VentaId debe ser mayor o igual a 0.");
            }

            try
            {
                var lineaDeVentaDTO = await _lineaDeVentaService.AgregarLineaDeVenta(
                    ventaId,
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

        [HttpDelete("{ventaId}/lineadeventa/quitar/{lineaDeVentaId}")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> QuitarLineaDeVenta(
            [Required][Range(0, int.MaxValue)] int ventaId,
            [Required][Range(0, int.MaxValue)] int lineaDeVentaId)
        {
            if (ventaId < 0 || lineaDeVentaId < 0)
            {
                return BadRequest("ventaId y lineaDeVentaId deben ser mayor o igual a 0.");
            }

            try
            {
                var ventaDTO = await _lineaDeVentaService.QuitarLineaDeVenta(
                    ventaId,
                    lineaDeVentaId);

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

        [HttpPut("{ventaId}/cliente/modificar")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> ModificarCliente(
            [Range(0, int.MaxValue)] int ventaId,
            [FromBody] int clienteId)
        {
            if (ventaId < 0)
            {
                return BadRequest("VentaId debe ser mayor o igual a 0.");
            }
            else if (clienteId < 0)
            {
                return BadRequest("ClienteId debe ser mayor o igual a 0.");
            }

            try
            {
                var ventaDto = await _ventaService.ModificarCliente(ventaId, clienteId);

                return Ok(ventaDto);
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

        [NonAction]
        [HttpPost("actualizarmonto/{ventaId}")]
        [ApiExplorerSettings(GroupName = "UseCases")]
        public async Task<IActionResult> ActualizarMonto(
           [FromQuery][Required][Range(0, int.MaxValue)] int ventaId)
        {
            try
            {
                var ventaDTO = await _ventaService.ActualizarMonto(ventaId);

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
        public async Task<IActionResult> CancelarVenta([FromQuery] int ventaId)
        {
            try
            {
                VentaDTO ventaCanceladaDTO = await _ventaService.CancelarVenta(ventaId);

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
        public async Task<IActionResult> FinalizarVenta(
            int ventaId,
            [FromBody] FinalizarVentaRequest request)
        {
            if (ventaId < 0)
            {
                return BadRequest("VentaId debe ser mayor o igual a 0.");
            }

            try
            {
                await _ventaService.FinalizarVenta(ventaId, request.EsTarjeta, request.DatosTarjeta);

                return Ok($"Venta con ID {ventaId} finalizada correctamente.");
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
        [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe ser mayor que cero.")]
        public int Cantidad { get; init; }

        [Required]
        public int InventarioId { get; init; }
    }
}
