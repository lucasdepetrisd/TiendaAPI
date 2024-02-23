using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TiendaDTO
{
    public int IdTienda { get; init; }
    public string Cuit { get; init; } = null!;

    public virtual ViewCondicionTributariaDTO CondicionTributaria { get; init; } = null!;
    
    public virtual ICollection<ViewSucursalDTO> Sucursales { get; init; } = new List<ViewSucursalDTO>();
}

public record ViewTiendaDTO
{
    public int IdTienda { get; init; }
    public string Cuit { get; init; } = null!;
    public int IdCondicionTributaria { get; init; }
}
