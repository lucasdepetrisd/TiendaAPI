using Application.Contracts.ViewServices;
using Application.DTOs;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.UseCasesServices
{
    public class ComprobanteService : ViewService<Comprobante, ComprobanteDTO>, IComprobanteService
    {
        public ComprobanteService(
            ICrudRepository<Comprobante> comprobanteRepository,
            IMapper mapper) : base(comprobanteRepository, mapper)
        {
        }
    }
}
