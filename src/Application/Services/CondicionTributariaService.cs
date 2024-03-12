using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CondicionTributariaService : ViewService<CondicionTributaria, CondicionTributariaDTO>, ICondicionTributariaService
    {
        public CondicionTributariaService(
            IViewRepository<CondicionTributaria> condiciontributariaRepository,
            IMapper mapper)
            : base(condiciontributariaRepository, mapper)
        {
        }
    }
}
