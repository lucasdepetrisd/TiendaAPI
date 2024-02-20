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
    public class SesionController : BaseController<Sesion, SesionDTO, CreateSesionDTO>
    {
        public SesionController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override Expression<Func<Sesion, object>>[] NavigationPropertiesToLoad
        => [a => a.Usuario, a => a.PuntoDeVenta];
    }
}
