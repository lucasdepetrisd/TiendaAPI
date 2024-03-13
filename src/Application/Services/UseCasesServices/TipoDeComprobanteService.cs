using Application.Contracts.CrudServices;
using Application.DTOs;
using Application.Services.CrudServices;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.UseCasesServices
{
    public class TipoDeComprobanteService : CrudService<TipoDeComprobante, CreateTipoDeComprobanteDTO, TipoDeComprobanteDTO>, ITipoDeComprobanteService
    {
        public TipoDeComprobanteService(
            ICrudRepository<TipoDeComprobante> tipodecomprobanteRepository,
            IMapper mapper) : base(tipodecomprobanteRepository, mapper)
        {
        }
    }
}
