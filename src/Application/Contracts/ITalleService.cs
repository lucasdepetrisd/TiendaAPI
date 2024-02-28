using Domain.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface ITalleService : IBaseService<CreateTalleDTO, TalleDTO>
    {
    }
}