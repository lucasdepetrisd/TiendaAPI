using Application.Contracts;
using AutoMapper;
using Domain.Repositories;

namespace Application.Services
{
    public abstract class CrudService<TEntity, TRequestDTO, TResponseDTO> : ViewService<TEntity, TResponseDTO>, ICrudService<TRequestDTO, TResponseDTO>
    where TRequestDTO : class
    where TResponseDTO : class
    {
        protected internal readonly ICrudRepository<TEntity> _entityCrudRepository;

        public CrudService(
            ICrudRepository<TEntity> entityCrudRepository,
            IMapper mapper) : base(entityCrudRepository, mapper)
        {
            _entityCrudRepository = entityCrudRepository;
        }

        public virtual async Task<TResponseDTO> AddAsync(TRequestDTO requestDTO)
        {
            var entityDB = _mapper.Map<TEntity>(requestDTO);

            await _entityCrudRepository.AddAsync(entityDB);

            var responseDTO = _mapper.Map<TResponseDTO>(entityDB);

            return responseDTO;
        }

        public virtual async Task<TResponseDTO?> UpdateAsync(int id, TRequestDTO requestDTO)
        {
            var entityDB = _entityViewRepository.GetByIdAsync(id).Result;

            if (entityDB == null)
            {
                return null;
            }

            _mapper.Map(requestDTO, entityDB);

            await _entityCrudRepository.UpdateAsync(entityDB);

            var responseDTO = _mapper.Map<TResponseDTO>(entityDB);
            return responseDTO;
        }

        public virtual async Task<bool> RemoveAsync(int id)
        {
            var entityDB = await _entityViewRepository.GetByIdAsync(id);

            if (entityDB == null)
            {
                return false;
            }

            await _entityCrudRepository.RemoveAsync(id);
            return true;
        }

        private async Task<bool> EntityExists(int id)
        {
            var entity = await _entityViewRepository.GetByIdAsync(id);
            return entity != null;
        }
    }
}
