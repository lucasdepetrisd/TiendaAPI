using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
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
