using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TiendaDTO
{
    public int IdTienda { get; set; }
    public string Cuit { get; set; } = null!;

    public virtual ViewCondicionTributariaDTO CondicionTributaria { get; set; } = null!;
    
    public virtual ICollection<ViewSucursalDTO> Sucursales { get; set; } = new List<ViewSucursalDTO>();
}

public record ViewTiendaDTO
{
    public int IdTienda { get; set; }
    public string Cuit { get; set; } = null!;
    public int IdCondicionTributaria { get; set; }
}
