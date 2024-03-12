using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ViewController<TiendaDTO>
    {
        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
            : base(tiendaService)
        {
            _tiendaService = tiendaService;
        }
    }
}
