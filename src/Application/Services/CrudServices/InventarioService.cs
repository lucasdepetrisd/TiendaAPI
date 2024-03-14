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
    public class InventarioService : CrudService<Inventario, CreateInventarioDTO, InventarioDTO>, IInventarioService
    {
        public InventarioService(ICrudRepository<Inventario> inventarioRepository, IMapper mapper) : base(inventarioRepository, mapper)
        {
        }
    }
}
