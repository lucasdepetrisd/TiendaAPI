using Application.Contracts.ViewServices;
using Application.DTOs.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ViewControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionTributariaController : ViewController<CondicionTributariaDTO>
    {
        public CondicionTributariaController(ICondicionTributariaService condicionTributariaService)
            : base(condicionTributariaService)
        {
        }
    }
}
