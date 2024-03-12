using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class ComprobanteService : ViewService<Comprobante, ComprobanteDTO>, IComprobanteService
    {
        public ComprobanteService(ICrudRepository<Comprobante> comprobanteRepository, IMapper mapper) : base(comprobanteRepository, mapper)
        {
        }
    }
}
