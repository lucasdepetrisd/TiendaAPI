using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : CrudController<CreateInventarioDTO, InventarioDTO>
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
            : base(inventarioService, inventarioService)
        {
            this._inventarioService = inventarioService;
        }
    }
}
