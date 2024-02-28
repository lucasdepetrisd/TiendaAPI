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
    public class RolService : BaseService<Rol, CreateRolDTO, RolDTO>, IRolService
    {
        public RolService(IRepository<Rol> rolRepository, IMapper mapper) : base(rolRepository, mapper)
        {
        }
    }
}
