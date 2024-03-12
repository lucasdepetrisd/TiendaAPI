using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
