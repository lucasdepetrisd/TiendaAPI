﻿using Application.Contracts.CrudServices;
using Application.DTOs.Admin.Articulo;

namespace Application.Contracts.UseCasesServices
{
    public interface IArticuloService : ICrudService<CreateArticuloDTO, ArticuloDTO>
    {
        Task<ArticuloDTO?> GetByCodigoAsync(string codigo);
    }
}