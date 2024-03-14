using Application.Contracts.CrudServices;
using Application.DTOs.Admin.Articulo;
using AutoMapper;
using Domain.Models.Articulo;
using Domain.Repositories;

namespace Application.Services.CrudServices
{
    public class ColorService : CrudService<Color, CreateColorDTO, ColorDTO>, IColorService
    {
        public ColorService(ICrudRepository<Color> colorRepository, IMapper mapper) : base(colorRepository, mapper)
        {
        }
    }
}
