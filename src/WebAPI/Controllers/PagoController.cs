using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : BaseController<CreatePagoDTO, PagoDTO>
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
            : base(pagoService)
        {
            _pagoService = pagoService;
        }
    }
}
