using Application.Contracts.ViewServices;
using Application.DTOs.Admin;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Repositories.ViewRepositories;

namespace Application.Services.UseCasesServices
{
    public class TiendaService : ViewService<Tienda, TiendaDTO>, ITiendaService
    {
        public TiendaService(
            ITiendaRepository tiendaRepository,
            IMapper mapper) : base(tiendaRepository, mapper)
        {
        }
    }
}
