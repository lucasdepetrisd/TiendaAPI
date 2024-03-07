using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs;

public record SucursalDTO
{
    public int IdSucursal { get; init; }
    public string Nombre { get; init; } = null!;
    public string? Telefono { get; init; }
    public string Email { get; init; } = null!;
    public string Domicilio { get; init; } = null!;
    public string Ciudad { get; init; } = null!;

    public virtual ViewTiendaDTO Tienda { get; init; } = null!;

    public virtual ICollection<ViewEmpleadoDTO> Empleados { get; init; } = new List<ViewEmpleadoDTO>();

    public virtual ICollection<ViewPuntoDeVentaDTO> PuntosDeVentas { get; init; } = new List<ViewPuntoDeVentaDTO>();
}

public record CreateSucursalDTO
{
    public string Nombre { get; init; } = null!;
    public string? Telefono { get; init; }
    public string Email { get; init; } = null!;
    public string Domicilio { get; init; } = null!;
    public string Ciudad { get; init; } = null!;

    public int IdTienda { get; init; }
}

public record ViewSucursalDTO
{
    public int IdSucursal { get; init; }
    public string Nombre { get; init; } = null!;
    public string? Telefono { get; init; }
    public string Email { get; init; } = null!;
    public string Domicilio { get; init; } = null!;
    public string Ciudad { get; init; } = null!;

    public int IdTienda { get; init; }
}
