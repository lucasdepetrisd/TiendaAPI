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
    public class SucursalService : BaseService<Sucursal, CreateSucursalDTO, SucursalDTO>, ISucursalService
    {
        public SucursalService(IRepository<Sucursal> sucursalRepository, IMapper mapper) : base(sucursalRepository, mapper)
        {
        }
    }
}
