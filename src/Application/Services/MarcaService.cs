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
    public class MarcaService : BaseService<Marca, CreateMarcaDTO, MarcaDTO>, IMarcaService
    {
        public MarcaService(IRepository<Marca> marcaRepository, IMapper mapper) : base(marcaRepository, mapper)
        {
        }
    }
}
