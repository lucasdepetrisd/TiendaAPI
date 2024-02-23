using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record ClienteDTO
{
    public int IdCliente { get; init; }
    public string Dni { get; init; } = null!;
    public string Cuil { get; init; } = null!;
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    public string Domicilio { get; init; } = null!;

    public virtual ViewCondicionTributariaDTO? CondicionTributaria { get; init; }

    public virtual ICollection<ViewVentaDTO> Ventas { get; init; } = new List<ViewVentaDTO>();
}

public record CreateClienteDTO
{
    [Required] public string Dni { get; init; } = null!;
    [Required] public string Cuil { get; init; } = null!;
    [Required] public string Nombre { get; init; } = null!;
    [Required] public string Apellido { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    [Required] public string Domicilio { get; init; } = null!;
    [Required] public int IdCondicionTributaria { get; init; }
}

public record ViewClienteDTO
{
    public int IdCliente { get; init; }
    public string Dni { get; init; } = null!;
    public string Cuil { get; init; } = null!;
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    public string Domicilio { get; init; } = null!;

    public virtual ViewCondicionTributariaDTO? CondicionTributaria { get; init; }
}
