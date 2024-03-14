using Application.Contracts.UseCasesServices;
using Application.DTOs.Admin;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Repositories;

namespace Application.Services.UseCasesServices
{
    public class SesionService : ViewService<Sesion, SesionDTO>, ISesionService
    {
        public SesionService(
            ICrudRepository<Sesion> sesionRepository,
            IMapper mapper) : base(sesionRepository, mapper)
        {
        }
    }
}
