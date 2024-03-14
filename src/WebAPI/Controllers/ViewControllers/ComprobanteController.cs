using Application.Contracts.ViewServices;
using Application.DTOs.Ventas;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ViewControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ViewController<ComprobanteDTO>
    {
        public ComprobanteController(IComprobanteService comprobanteService)
            : base(comprobanteService)
        {
        }
    }
}
