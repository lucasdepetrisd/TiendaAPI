using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionTributariaController : BaseController<CreateCondicionTributariaDTO, CondicionTributariaDTO>
    {
        private readonly ICondicionTributariaService _condicionTributariaService;

        public CondicionTributariaController(ICondicionTributariaService condicionTributariaService)
            : base(condicionTributariaService)
        {
            _condicionTributariaService = condicionTributariaService;
        }
    }
}
