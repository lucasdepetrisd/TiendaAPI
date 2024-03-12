using AutoMapper;
using Application.DTOs;
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
    public class EmpleadoService : CrudService<Empleado, CreateEmpleadoDTO, EmpleadoDTO>, IEmpleadoService
    {
        public EmpleadoService(ICrudRepository<Empleado> empleadoRepository, IMapper mapper) : base(empleadoRepository, mapper)
        {
        }
    }
}
