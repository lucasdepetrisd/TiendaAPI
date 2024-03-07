using Application.Contracts;
using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CondicionTributariaService : BaseService<CondicionTributaria, CondicionTributariaDTO, CondicionTributariaDTO>, ICondicionTributariaService
    {
        public CondicionTributariaService(IRepository<CondicionTributaria> condiciontributariaRepository, IMapper mapper) : base(condiciontributariaRepository, mapper)
        {
        }

        public override Task<CondicionTributariaDTO> AddAsync(CondicionTributariaDTO requestDTO)
        {
            throw new NotSupportedException("Adding CondicionTributaria entities is not supported.");
        }

        public override Task<bool> RemoveAsync(int id)
        {
            throw new NotSupportedException("Adding CondicionTributaria entities is not supported.");
        }
    }
}
