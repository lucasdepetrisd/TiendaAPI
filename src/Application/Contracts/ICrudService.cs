﻿namespace Application.Contracts
{
    public interface ICrudService<TRequestDTO, TResponseDTO> : IViewService<TResponseDTO>
    {
        Task<TResponseDTO> AddAsync(TRequestDTO requestDTO);
        Task<TResponseDTO?> UpdateAsync(int id, TRequestDTO requestDTO);
        Task<bool> RemoveAsync(int id);
    }
}
