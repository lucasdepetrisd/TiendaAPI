using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : BaseController<CreateEmpleadoDTO, EmpleadoDTO>
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
            : base(empleadoService)
        {
            _empleadoService = empleadoService;
        }
    }
}
