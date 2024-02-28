using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : BaseController<CreateMarcaDTO, MarcaDTO>
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
            : base(marcaService)
        {
            _marcaService = marcaService;
        }
    }
}
