using Application.Contracts.ViewServices;
using Application.DTOs.Admin;
using AutoMapper;
using Domain.Models.Admin;
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
