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
    public class TalleService : BaseService<Talle, CreateTalleDTO, TalleDTO>, ITalleService
    {
        public TalleService(IRepository<Talle> talleRepository, IMapper mapper) : base(talleRepository, mapper)
        {
        }
    }
}
