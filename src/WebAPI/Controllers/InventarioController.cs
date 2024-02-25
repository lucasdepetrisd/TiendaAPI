using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : BaseController<CreateInventarioDTO, InventarioDTO>
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
            : base(inventarioService)
        {
            this._inventarioService = inventarioService;
        }
    }
}
