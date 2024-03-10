using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : CrudController<CreateEmpleadoDTO, EmpleadoDTO>
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
            : base(empleadoService)
        {
            _empleadoService = empleadoService;
        }
    }
}
