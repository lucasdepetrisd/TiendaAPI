using AutoMapper;
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
    public class TiendaService : BaseService<Tienda, TiendaDTO, TiendaDTO>, ITiendaService
    {
        public TiendaService(IRepository<Tienda> tiendaRepository, IMapper mapper) : base(tiendaRepository, mapper)
        {
        }

        public override Task<TiendaDTO> AddAsync(TiendaDTO requestDTO)
        {
            throw new NotSupportedException("Adding Tienda entities is not supported.");
        }

        public override Task<bool> RemoveAsync(int id)
        {
            throw new NotSupportedException("Adding Tienda entities is not supported.");
        }
    }
}
