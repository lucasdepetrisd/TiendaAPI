using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.CrudServices;
using Application.DTOs.Admin;
using Domain.Models.Admin;

namespace Application.Services.CrudServices
{
    public class PuntoDeVentaService : CrudService<PuntoDeVenta, CreatePuntoDeVentaDTO, PuntoDeVentaDTO>, IPuntoDeVentaService
    {
        public PuntoDeVentaService(ICrudRepository<PuntoDeVenta> puntodeventaRepository, IMapper mapper) : base(puntodeventaRepository, mapper)
        {
        }
    }
}
