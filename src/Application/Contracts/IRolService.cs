﻿using Application.DTOs;
using Domain.Models;

namespace Application.Contracts
{
    public interface IRolService : IBaseService<CreateRolDTO, RolDTO>
    {
    }
}