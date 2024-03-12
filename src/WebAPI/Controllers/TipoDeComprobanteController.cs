using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeComprobanteController : CrudController<CreateTipoDeComprobanteDTO, TipoDeComprobanteDTO>
    {
        private readonly ITipoDeComprobanteService _tipoDeComprobanteService;

        public TipoDeComprobanteController(ITipoDeComprobanteService tipoDeComprobanteService)
            : base(tipoDeComprobanteService, tipoDeComprobanteService)
        {
            _tipoDeComprobanteService = tipoDeComprobanteService;
        }
    }
}
