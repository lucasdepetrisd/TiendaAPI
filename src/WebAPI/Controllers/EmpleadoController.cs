using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : CrudController<CreateEmpleadoDTO, EmpleadoDTO>
    {
        public EmpleadoController(IEmpleadoService empleadoService)
            : base(empleadoService, empleadoService)
        {
        }
    }
}
