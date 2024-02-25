using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTalleController : BaseController<CreateTipoTalleDTO, TipoTalleDTO>
    {
        private readonly ITipoTalleService _tipoTalleService;

        public TipoTalleController(ITipoTalleService tipoTalleService)
            : base(tipoTalleService)
        {
            _tipoTalleService = tipoTalleService;
        }
    }
}
