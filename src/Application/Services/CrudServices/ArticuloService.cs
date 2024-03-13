using Application.Contracts.UseCasesServices;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.CrudServices
{
    public class ArticuloService : CrudService<Articulo, CreateArticuloDTO, ArticuloDTO>, IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository, IMapper mapper) : base(articuloRepository, mapper)
        {
            _articuloRepository = articuloRepository ?? throw new ArgumentNullException(nameof(articuloRepository));
        }

        public async Task<ArticuloDTO?> GetByCodigoAsync(string codigo)
        {
            var articulo = await _articuloRepository.GetByCodigoAsync(codigo);

            ArticuloDTO articuloDTO = _mapper.Map<ArticuloDTO>(articulo);

            return articuloDTO;
        }
    }
}
