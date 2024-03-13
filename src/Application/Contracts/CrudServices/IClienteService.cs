using Application.DTOs;

namespace Application.Contracts.CrudServices
{
    public interface IClienteService : ICrudService<CreateClienteDTO, ClienteDTO>
    {
    }
}