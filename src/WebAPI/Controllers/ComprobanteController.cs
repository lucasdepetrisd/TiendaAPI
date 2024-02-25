using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : BaseController<CreateComprobanteDTO, ComprobanteDTO>
    {
        private readonly IComprobanteService _comprobanteService;

        public ComprobanteController(IComprobanteService comprobanteService)
            : base(comprobanteService)
        {
            _comprobanteService = comprobanteService;
        }
    }
}
