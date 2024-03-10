using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : CrudController<CreateSucursalDTO, SucursalDTO>
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
            : base(sucursalService)
        {
            _sucursalService = sucursalService;
        }
    }
}
