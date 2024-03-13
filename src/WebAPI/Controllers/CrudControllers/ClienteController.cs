using Application.Contracts.CrudServices;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CrudControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : CrudController<CreateClienteDTO, ClienteDTO>
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
            : base(clienteService, clienteService)
        {
            _clienteService = clienteService;
        }
    }
}
