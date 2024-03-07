﻿using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IComprobanteService : IBaseService<CreateComprobanteDTO, ComprobanteDTO>
    {
    }
}