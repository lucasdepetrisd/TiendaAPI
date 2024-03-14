using Application.Contracts.ViewServices;
using Application.DTOs.Admin;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Repositories.ViewRepositories;

namespace Application.Services.CrudServices
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
