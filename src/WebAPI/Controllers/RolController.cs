using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : CrudController<CreateRolDTO, RolDTO>
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
            : base(rolService)
        {
            _rolService = rolService;
        }
    }
}
