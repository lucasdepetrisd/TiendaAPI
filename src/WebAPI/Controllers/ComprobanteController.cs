using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : CrudController<CreateComprobanteDTO, ComprobanteDTO>
    {
        private readonly IComprobanteService _comprobanteService;

        public ComprobanteController(IComprobanteService comprobanteService)
            : base(comprobanteService)
        {
            _comprobanteService = comprobanteService;
        }
    }
}
