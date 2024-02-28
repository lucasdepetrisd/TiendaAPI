using Domain.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IMarcaService : IBaseService<CreateMarcaDTO, MarcaDTO>
    {
    }
}