using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : BaseController<CreateRolDTO, RolDTO>
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
            : base(rolService)
        {
            _rolService = rolService;
        }
    }
}
