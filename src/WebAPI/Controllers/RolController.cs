using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : CrudController<CreateRolDTO, RolDTO>
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
            : base(rolService, rolService)
        {
            _rolService = rolService;
        }
    }
}
