using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ViewController<PagoDTO>
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
            : base(pagoService)
        {
            _pagoService = pagoService;
        }
    }
}
