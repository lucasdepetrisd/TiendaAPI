using Microsoft.AspNetCore.Mvc;
using Application.Data;
using Domain.Models;
using AutoMapper;
using Domain.DTOs;
using System.Linq.Expressions;
using WebAPI.Controllers;

namespace Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController<Categoria, CategoriaDTO, CreateCategoriaDTO>
    {
        public CategoriaController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Categoria, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];
    }
}
