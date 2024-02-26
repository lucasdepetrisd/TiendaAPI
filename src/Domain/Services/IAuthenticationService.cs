using Domain.DTOs;

namespace Domain.Services
{
    public interface IAuthenticationService
    {
        Task<SesionDTO?> CerrarSesion(int sesionId);
        Task<SesionDTO?> IniciarSesion(int puntoDeVentaId, string username, string password);
    }
}