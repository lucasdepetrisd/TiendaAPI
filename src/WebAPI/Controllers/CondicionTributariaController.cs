using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
