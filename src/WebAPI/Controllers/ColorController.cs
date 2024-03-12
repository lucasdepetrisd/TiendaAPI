using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
