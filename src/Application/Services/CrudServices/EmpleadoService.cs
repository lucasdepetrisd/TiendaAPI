﻿using AutoMapper;
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
    public class EmpleadoService : CrudService<Empleado, CreateEmpleadoDTO, EmpleadoDTO>, IEmpleadoService
    {
        public EmpleadoService(ICrudRepository<Empleado> empleadoRepository, IMapper mapper) : base(empleadoRepository, mapper)
        {
        }
    }
}