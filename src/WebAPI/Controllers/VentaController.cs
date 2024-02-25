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

        [HttpPost("{usuarioId}/{puntoDeVentaId}")]
        public async Task<IActionResult> IniciarVentaAsync(int usuarioId, int puntoDeVentaId)
        {
            try
            {
                var venta = await _ventaService.IniciarVenta(usuarioId, puntoDeVentaId);

                return Ok(venta);
            }
            catch (DbException ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating {typeof(VentaDTO).Name}. Error: {errorMessage}");
            }
            /*catch (Exception ex)
            {
                string? errorMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {errorMessage}");
            }*/
        }
    }
}
