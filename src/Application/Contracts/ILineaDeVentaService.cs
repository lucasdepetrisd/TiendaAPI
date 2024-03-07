using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface ILineaDeVentaService : IBaseService<CreateLineaDeVentaDTO, LineaDeVentaDTO>
    {
    }
}