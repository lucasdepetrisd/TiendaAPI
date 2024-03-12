using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class SucursalService : ViewService<Sucursal, SucursalDTO>, ISucursalService
    {
        public SucursalService(
            IViewRepository<Sucursal> sucursalRepository,
            IMapper mapper) : base(sucursalRepository, mapper)
        {
        }
    }
}
