using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoDeVentaController : BaseController<CreatePuntoDeVentaDTO, PuntoDeVentaDTO>
    {
        private readonly IPuntoDeVentaService _puntoDeVentaService;

        public PuntoDeVentaController(IPuntoDeVentaService puntoDeVentaService)
            : base(puntoDeVentaService)
        {
            _puntoDeVentaService = puntoDeVentaService;
        }
    }
}
