using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : CrudController<CreatePagoDTO, PagoDTO>
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
            : base(pagoService)
        {
            _pagoService = pagoService;
        }
    }
}
