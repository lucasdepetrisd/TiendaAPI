﻿using Domain.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IPagoService : IBaseService<CreatePagoDTO, PagoDTO>
    {
    }
}