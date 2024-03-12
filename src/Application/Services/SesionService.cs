using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class SesionService : ViewService<Sesion, SesionDTO>, ISesionService
    {
        public SesionService(ICrudRepository<Sesion> sesionRepository, IMapper mapper) : base(sesionRepository, mapper)
        {
        }
    }
}
