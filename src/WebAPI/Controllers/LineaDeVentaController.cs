using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineaDeVentaController : BaseController<CreateLineaDeVentaDTO, LineaDeVentaDTO>
    {
        private readonly ILineaDeVentaService _lineaDeVentaService;

        public LineaDeVentaController(ILineaDeVentaService lineaDeVentaService)
            : base(lineaDeVentaService)
        {
            _lineaDeVentaService = lineaDeVentaService;
        }
    }
}
