using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBaseService<TRequestDTO, TResponseDTO>
    {
        Task<List<TResponseDTO>> GetAllAsync();
        Task<TResponseDTO?> GetByIdAsync(int id);
        Task<TResponseDTO> AddAsync(TRequestDTO requestDTO);
        Task<TResponseDTO?> UpdateAsync(int id, TRequestDTO requestDTO);
        Task<bool> RemoveAsync(int id);
    }
}
