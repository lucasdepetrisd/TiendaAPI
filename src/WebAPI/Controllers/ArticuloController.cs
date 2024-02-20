using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Application.Data;
using AutoMapper;
using Domain.DTOs;
using System.Collections;
using Application.Repositories;
using WebAPI.Controllers;
using System.Linq.Expressions;

namespace Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : BaseController<Articulo, ArticuloDTO, CreateArticuloDTO>
    {
        public ArticuloController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /*protected override Expression<Func<Articulo, bool>> PrimaryKeyPredicate(int id)
        {
            return articulo => articulo.IdArticulo == id;
        }*/

        protected override Expression<Func<Articulo, object>>[] NavigationPropertiesToLoad
        => [a => a.Categoria, a => a.Marca, a => a.TipoTalle];
    }
}
