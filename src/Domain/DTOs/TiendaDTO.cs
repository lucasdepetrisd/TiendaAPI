using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TiendaDTO
{
    [Key]
    public int IdTienda { get; set; }

    public string Cuit { get; set; } = null!;

    public int IdCondicionTributaria { get; set; }
    public virtual CondicionTributariaDTO CondicionTributaria { get; set; } = null!;

    public virtual ICollection<SucursalDTO> Sucursales { get; set; } = new List<SucursalDTO>();
}
