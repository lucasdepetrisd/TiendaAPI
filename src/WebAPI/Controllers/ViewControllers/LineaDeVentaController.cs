using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ViewControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineaDeVentaController : ViewController<LineaDeVentaDTO>
    {
        private readonly ILineaDeVentaService _lineaDeVentaService;

        public LineaDeVentaController(ILineaDeVentaService lineaDeVentaService)
            : base(lineaDeVentaService)
        {
            _lineaDeVentaService = lineaDeVentaService;
        }
    }
}
