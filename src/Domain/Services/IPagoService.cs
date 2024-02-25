using Domain.DTOs;
using Domain.Models;

namespace Domain.Services
{
    public interface IPagoService : IBaseService<CreatePagoDTO, PagoDTO>
    {
    }
}