using Domain.DTOs;

namespace Domain.Services
{
    public interface IVentaService : IBaseService<CreateVentaDTO, VentaDTO>
    {
        Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId);
    }
}