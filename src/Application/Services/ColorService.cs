using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class ColorService : CrudService<Color, CreateColorDTO, ColorDTO>, IColorService
    {
        public ColorService(ICrudRepository<Color> colorRepository, IMapper mapper) : base(colorRepository, mapper)
        {
        }
    }
}
