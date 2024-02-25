using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface IClienteService : IBaseService<CreateClienteDTO, ClienteDTO>
    {
    }
}