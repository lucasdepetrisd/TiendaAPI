using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : CrudController<CreateInventarioDTO, InventarioDTO>
    {
        public InventarioController(IInventarioService inventarioService)
            : base(inventarioService, inventarioService)
        {
        }
    }
}
