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
    public class TipoTalleController : BaseController<TipoTalle, TipoTalleDTO, CreateTipoTalleDTO>
    {
        public TipoTalleController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<TipoTalle, object>>[] NavigationPropertiesToLoad
        => [a => a.Talles];
    }
}
