using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : CrudController<CreateCategoriaDTO, CategoriaDTO>
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
            : base(categoriaService)
        {
            _categoriaService = categoriaService;
        }
    }
}
