using Application.Contracts.ViewServices;
using Application.DTOs.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ViewControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ViewController<SucursalDTO>
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
            : base(sucursalService)
        {
            _sucursalService = sucursalService;
        }
    }
}
