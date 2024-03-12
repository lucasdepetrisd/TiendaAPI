using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTalleController : CrudController<CreateTipoTalleDTO, TipoTalleDTO>
    {
        private readonly ITipoTalleService _tipoTalleService;

        public TipoTalleController(ITipoTalleService tipoTalleService)
            : base(tipoTalleService, tipoTalleService)
        {
            _tipoTalleService = tipoTalleService;
        }
    }
}
