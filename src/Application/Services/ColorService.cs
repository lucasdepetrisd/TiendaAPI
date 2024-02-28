using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ColorService : BaseService<Color, CreateColorDTO, ColorDTO>, IColorService
    {
        public ColorService(IRepository<Color> colorRepository, IMapper mapper) : base(colorRepository, mapper)
        {
        }
    }
}
