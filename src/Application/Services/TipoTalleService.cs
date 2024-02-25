﻿using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TipoTalleService : BaseService<TipoTalle, CreateTipoTalleDTO, TipoTalleDTO>, ITipoTalleService
    {
        public TipoTalleService(IRepository<TipoTalle> tipotalleRepository, IMapper mapper) : base(tipotalleRepository, mapper)
        {
        }
    }
}
