using Application.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : CrudController<CreateClienteDTO, ClienteDTO>
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }
    }
}
