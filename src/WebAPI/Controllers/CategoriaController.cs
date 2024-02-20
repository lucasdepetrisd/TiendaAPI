using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
