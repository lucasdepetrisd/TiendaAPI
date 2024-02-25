using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleController : BaseController<CreateTalleDTO, TalleDTO>
    {
        private readonly ITalleService _talleService;

        public TalleController(ITalleService talleService)
            : base(talleService)
        {
            _talleService = talleService;
        }
    }
}
