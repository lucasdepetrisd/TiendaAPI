using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : BaseController<CreateArticuloDTO, ArticuloDTO>
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
            : base(articuloService)
        {
            _articuloService = articuloService;
        }
    }
}
