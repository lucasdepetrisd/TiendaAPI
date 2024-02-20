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
    public class CondicionTributariaController : BaseController<CondicionTributaria, CondicionTributariaDTO, CreateCondicionTributariaDTO>
    {
        public CondicionTributariaController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<CondicionTributaria, object>>[] NavigationPropertiesToLoad
        => [a => a.TipoDeComprobante];
    }
}
