using Application.Contracts.CrudServices;
using Application.DTOs.Admin;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Repositories;

namespace Application.Services.CrudServices
{
    public class ClienteService : CrudService<Cliente, CreateClienteDTO, ClienteDTO>, IClienteService
    {
        public ClienteService(ICrudRepository<Cliente> clienteRepository, IMapper mapper) : base(clienteRepository, mapper)
        {
        }
    }
}
