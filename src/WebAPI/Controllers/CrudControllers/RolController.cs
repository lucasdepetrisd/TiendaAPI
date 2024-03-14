using Application.Contracts.CrudServices;
using Application.DTOs.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CrudControllers
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
