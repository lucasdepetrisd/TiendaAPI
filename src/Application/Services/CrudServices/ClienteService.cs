﻿using Application.Contracts.CrudServices;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.CrudServices
{
    public class ClienteService : CrudService<Cliente, CreateClienteDTO, ClienteDTO>, IClienteService
    {
        public ClienteService(ICrudRepository<Cliente> clienteRepository, IMapper mapper) : base(clienteRepository, mapper)
        {
        }
    }
}