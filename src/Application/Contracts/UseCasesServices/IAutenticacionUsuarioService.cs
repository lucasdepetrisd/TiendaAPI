using Application.DTOs;

namespace Application.Contracts.UseCasesServices
{
    public interface IAutenticacionUsuarioService
    {
        Task<SesionDTO?> CerrarSesion(int sesionId);
        Task<SesionDTO?> IniciarSesion(int puntoDeVentaId, string username, string password);
    }
}