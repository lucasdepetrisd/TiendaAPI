using Microsoft.AspNetCore.Mvc;
using Application.Data;
using AutoMapper;
using Domain.DTOs;
using System.Linq.Expressions;
using Domain.Models;
using WebAPI.Controllers;

namespace Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : BaseController<Inventario, InventarioDTO, CreateInventarioDTO>
    {
        public InventarioController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Inventario, object>>[] NavigationPropertiesToLoad 
            => new Expression<Func<Inventario, object>>[] 
        {
            a => a.Articulo, 
            a => a.Articulo.Marca, 
            a => a.Articulo.TipoTalle, 
            a => a.Articulo.Categoria, 
            a => a.Sucursal, 
            a => a.Color, 
            a => a.Talle
        };
    }
}
