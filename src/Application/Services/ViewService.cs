using Application.Contracts;
using AutoMapper;
using Domain.Repositories;

namespace Application.Services
{
    public class ViewService<TEntity, TResponseDTO> : IViewService<TResponseDTO>
        where TResponseDTO : class
    {
        protected internal readonly IViewRepository<TEntity> _entityViewRepository;
        protected internal readonly IMapper _mapper;

        public ViewService(IViewRepository<TEntity> entityViewRepository, IMapper mapper)
        {
            _entityViewRepository = entityViewRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<TResponseDTO>> GetAllAsync()
        {
            List<TEntity> entities = await _entityViewRepository.GetAllAsync();

            List<TResponseDTO> entityDTOs = _mapper.Map<List<TResponseDTO>>(entities);

            return entityDTOs;
        }

        public virtual async Task<TResponseDTO?> GetByIdAsync(int id)
        {
            var entity = await _entityViewRepository.GetByIdAsync(id);

            TResponseDTO entityDTO = _mapper.Map<TResponseDTO>(entity);

            return entityDTO;
        }
    }
}