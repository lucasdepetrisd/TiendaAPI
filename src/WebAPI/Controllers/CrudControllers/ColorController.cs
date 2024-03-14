using Application.Contracts.CrudServices;
using Application.DTOs.Admin.Articulo;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CrudControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : CrudController<CreateColorDTO, ColorDTO>
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
            : base(colorService, colorService)
        {
            _colorService = colorService;
        }
    }
}
