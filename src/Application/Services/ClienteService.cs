﻿using AutoMapper;
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
    public class ClienteService : BaseService<Cliente, CreateClienteDTO, ClienteDTO>, IClienteService
    {
        public ClienteService(IRepository<Cliente> clienteRepository, IMapper mapper) : base(clienteRepository, mapper)
        {
        }
    }
}