using Application.Contracts.CrudServices;
using Application.DTOs.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CrudControllers
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
