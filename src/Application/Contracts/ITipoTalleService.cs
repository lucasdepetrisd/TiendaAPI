using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface ITipoTalleService : IBaseService<CreateTipoTalleDTO, TipoTalleDTO>
    {
    }
}