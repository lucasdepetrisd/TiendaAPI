using Application.Contracts.CrudServices;
using Application.DTOs.Ventas;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.CrudControllers;

namespace WebAPI.Controllers.ViewControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeComprobanteController : ViewController<TipoDeComprobanteDTO>
    {
        public TipoDeComprobanteController(ITipoDeComprobanteService tipoDeComprobanteService)
            : base(tipoDeComprobanteService)
        {
        }
    }
}
