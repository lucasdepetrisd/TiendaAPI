using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : CrudController<CreateMarcaDTO, MarcaDTO>
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
            : base(marcaService, marcaService)
        {
            _marcaService = marcaService;
        }
    }
}
