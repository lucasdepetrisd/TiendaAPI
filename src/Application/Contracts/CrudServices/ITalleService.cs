using Application.DTOs;

namespace Application.Contracts.CrudServices
{
    public interface ITalleService : ICrudService<CreateTalleDTO, TalleDTO>
    {
    }
}