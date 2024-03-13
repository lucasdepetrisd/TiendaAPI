using Application.Contracts.ViewServices;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories.ViewRepositories;

namespace Application.Services.ViewServices
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
