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
    public class TalleController : BaseController<Talle, TalleDTO, CreateTalleDTO>
    {
        public TalleController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Talle, object>>[] NavigationPropertiesToLoad
        => [a => a.TipoTalle];
    }
}
