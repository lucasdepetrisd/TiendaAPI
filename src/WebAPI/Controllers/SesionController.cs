using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : BaseController<CreateSesionDTO, SesionDTO>
    {
        private readonly ISesionService _sesionService;

        public SesionController(ISesionService sesionService)
            : base(sesionService)
        {
            _sesionService = sesionService;
        }
    }
}
