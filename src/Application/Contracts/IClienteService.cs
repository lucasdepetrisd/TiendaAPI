using Application.DTOs;

namespace Application.Contracts
{
    public interface IClienteService : ICrudService<CreateClienteDTO, ClienteDTO>
    {
    }
}