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
    public class SesionService : BaseService<Sesion, CreateSesionDTO, SesionDTO>, ISesionService
    {
        public SesionService(IRepository<Sesion> sesionRepository, IMapper mapper) : base(sesionRepository, mapper)
        {
        }
    }
}
