using Application.Contracts.UseCasesServices;
using Application.DTOs.Ventas;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ViewControllers
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
