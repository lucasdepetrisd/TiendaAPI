using Application.Contracts.CrudServices;
using Application.DTOs.Admin.Articulo;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CrudControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleController : CrudController<CreateTalleDTO, TalleDTO>
    {
        private readonly ITalleService _talleService;

        public TalleController(ITalleService talleService)
            : base(talleService, talleService)
        {
            _talleService = talleService;
        }
    }
}
