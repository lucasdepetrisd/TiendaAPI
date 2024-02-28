using Domain.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IClienteService : IBaseService<CreateClienteDTO, ClienteDTO>
    {
    }
}