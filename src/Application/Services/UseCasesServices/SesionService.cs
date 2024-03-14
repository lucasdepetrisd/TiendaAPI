using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models;
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
