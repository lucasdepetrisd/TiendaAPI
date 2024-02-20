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
    public class ClienteController : BaseController<Cliente, ClienteDTO, CreateClienteDTO>
    {
        public ClienteController(ITiendaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /*protected override Expression<Func<Cliente, object>>[] NavigationPropertiesToLoad
        => [a => a.Articulos];*/
    }
}
