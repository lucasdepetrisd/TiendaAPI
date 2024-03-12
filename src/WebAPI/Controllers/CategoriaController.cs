using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : CrudController<CreateCategoriaDTO, CategoriaDTO>
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
            : base(categoriaService, categoriaService)
        {
            _categoriaService = categoriaService;
        }
    }
}
