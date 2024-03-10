using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTalleController : CrudController<CreateTipoTalleDTO, TipoTalleDTO>
    {
        private readonly ITipoTalleService _tipoTalleService;

        public TipoTalleController(ITipoTalleService tipoTalleService)
            : base(tipoTalleService)
        {
            _tipoTalleService = tipoTalleService;
        }
    }
}
