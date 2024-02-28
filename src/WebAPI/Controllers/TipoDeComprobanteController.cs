using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeComprobanteController : BaseController<CreateTipoDeComprobanteDTO, TipoDeComprobanteDTO>
    {
        private readonly ITipoDeComprobanteService _tipoDeComprobanteService;

        public TipoDeComprobanteController(ITipoDeComprobanteService tipoDeComprobanteService)
            : base(tipoDeComprobanteService)
        {
            _tipoDeComprobanteService = tipoDeComprobanteService;
        }
    }
}
