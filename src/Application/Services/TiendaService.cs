using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
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
