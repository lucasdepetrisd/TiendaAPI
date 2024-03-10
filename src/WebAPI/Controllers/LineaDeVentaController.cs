using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineaDeVentaController : CrudController<CreateLineaDeVentaDTO, LineaDeVentaDTO>
    {
        private readonly ILineaDeVentaService _lineaDeVentaService;

        public LineaDeVentaController(ILineaDeVentaService lineaDeVentaService)
            : base(lineaDeVentaService)
        {
            _lineaDeVentaService = lineaDeVentaService;
        }
    }
}
