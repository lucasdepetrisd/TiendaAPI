using Application.Contracts.ViewServices;
using Application.DTOs.Ventas;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Ventas;
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
