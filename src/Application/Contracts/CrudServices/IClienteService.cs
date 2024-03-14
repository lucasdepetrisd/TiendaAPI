using Application.DTOs.Admin;

namespace Application.Contracts.CrudServices
{
    public interface IClienteService : ICrudService<CreateClienteDTO, ClienteDTO>
    {
    }
}