using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.CrudServices;
using Application.DTOs.Admin.Articulo;
using Domain.Models.Articulo;

namespace Application.Services.CrudServices
{
    public class MarcaService : CrudService<Marca, CreateMarcaDTO, MarcaDTO>, IMarcaService
    {
        public MarcaService(ICrudRepository<Marca> marcaRepository, IMapper mapper) : base(marcaRepository, mapper)
        {
        }
    }
}
