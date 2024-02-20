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
    public class ColorController : BaseController<Color, ColorDTO, CreateColorDTO>
    {
        public ColorController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
