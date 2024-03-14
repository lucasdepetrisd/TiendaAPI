using Application.Contracts.ViewServices;
using Application.DTOs;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models;
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
