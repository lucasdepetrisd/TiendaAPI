using Application.Contracts.CrudServices;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CrudControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoDeVentaController : CrudController<CreatePuntoDeVentaDTO, PuntoDeVentaDTO>
    {
        private readonly IPuntoDeVentaService _puntoDeVentaService;

        public PuntoDeVentaController(IPuntoDeVentaService puntoDeVentaService)
            : base(puntoDeVentaService, puntoDeVentaService)
        {
            _puntoDeVentaService = puntoDeVentaService;
        }
    }
}
