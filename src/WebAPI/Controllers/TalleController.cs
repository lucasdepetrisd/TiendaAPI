using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
