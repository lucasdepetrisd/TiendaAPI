using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
