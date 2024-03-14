using Application.Contracts.CrudServices;
using Application.DTOs.Ventas;
using Application.Services.CrudServices;
using AutoMapper;
using Domain.Models.Ventas;
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
