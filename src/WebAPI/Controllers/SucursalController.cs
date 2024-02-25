using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : BaseController<CreateSucursalDTO, SucursalDTO>
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
            : base(sucursalService)
        {
            _sucursalService = sucursalService;
        }
    }
}
