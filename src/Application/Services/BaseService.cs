using Application.Contracts;
using AutoMapper;
using Domain.Repositories;

namespace Application.Services;

public abstract class BaseService<TEntity, TRequestDTO, TResponseDTO> : IBaseService<TRequestDTO, TResponseDTO>
    where TRequestDTO : class
    where TResponseDTO : class
{
    private readonly IRepository<TEntity> _entityRepository;
    protected readonly IMapper _mapper;

    public BaseService(IRepository<TEntity> entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public virtual async Task<List<TResponseDTO>> GetAllAsync()
    {
        List<TEntity> entities = await _entityRepository.GetAllAsync();

        List<TResponseDTO> entityDTOs = _mapper.Map<List<TResponseDTO>>(entities);

        return entityDTOs;
    }

    public virtual async Task<TResponseDTO?> GetByIdAsync(int id)
    {
        var entity = await _entityRepository.GetByIdAsync(id);

        TResponseDTO entityDTO = _mapper.Map<TResponseDTO>(entity);

        return entityDTO;
    }

    public virtual async Task<TResponseDTO> AddAsync(TRequestDTO requestDTO)
    {
        var entityDB = _mapper.Map<TEntity>(requestDTO);

        await _entityRepository.AddAsync(entityDB);

        var responseDTO = _mapper.Map<TResponseDTO>(entityDB);
        return responseDTO;
    }

    public virtual async Task<TResponseDTO?> UpdateAsync(int id, TRequestDTO requestDTO)
    {
        var entityDB = _entityRepository.GetByIdAsync(id).Result;

        if (entityDB == null)
        {
            return null;
        }

        _mapper.Map(requestDTO, entityDB);

        await _entityRepository.UpdateAsync(entityDB);

        var responseDTO = _mapper.Map<TResponseDTO>(entityDB);
        return responseDTO;
    }

    public virtual async Task<bool> RemoveAsync(int id)
    {
        var entityDB = await _entityRepository.GetByIdAsync(id);

        if (entityDB == null)
        {
            return false;
        }

        await _entityRepository.RemoveAsync(id);
        return true;
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _entityRepository.GetByIdAsync(id);
        return entity != null;
    }
}
