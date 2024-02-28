using Domain.DTOs;

namespace Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<SesionDTO?> CerrarSesion(int sesionId);
        Task<SesionDTO?> IniciarSesion(int puntoDeVentaId, string username, string password);
    }
}