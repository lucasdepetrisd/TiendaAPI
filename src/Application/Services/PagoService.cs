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
    public class PagoService : BaseService<Pago, CreatePagoDTO, PagoDTO>, IPagoService
    {
        public PagoService(IRepository<Pago> pagoRepository, IMapper mapper) : base(pagoRepository, mapper)
        {
        }
    }
}