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
    public class LineaDeVentaService : BaseService<LineaDeVenta, CreateLineaDeVentaDTO, LineaDeVentaDTO>, ILineaDeVentaService
    {
        public LineaDeVentaService(IRepository<LineaDeVenta> lineadeventaRepository, IMapper mapper) : base(lineadeventaRepository, mapper)
        {
        }
    }
}
