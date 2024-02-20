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
    public class TipoDeComprobanteController : BaseController<TipoDeComprobante, TipoDeComprobanteDTO, CreateTipoDeComprobanteDTO>
    {
        public TipoDeComprobanteController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<TipoDeComprobante, object>>[] NavigationPropertiesToLoad
        => [a => a.CondicionesTributarias];
    }
}
