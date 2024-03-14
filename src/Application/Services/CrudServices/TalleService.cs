using AutoMapper;
using Application.DTOs;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.CrudServices;

namespace Application.Services.CrudServices
{
    public class TalleService : CrudService<Talle, CreateTalleDTO, TalleDTO>, ITalleService
    {
        public TalleService(ICrudRepository<Talle> talleRepository, IMapper mapper) : base(talleRepository, mapper)
        {
        }
    }
}
