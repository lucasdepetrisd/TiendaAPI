using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record SucursalDTO
{
    public int IdSucursal { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Telefono { get; set; }
    public string Email { get; set; } = null!;
    public string Domicilio { get; set; } = null!;
    public string Ciudad { get; set; } = null!;

    public virtual ViewTiendaDTO Tienda { get; set; } = null!;

    public virtual ICollection<ViewEmpleadoDTO> Empleados { get; set; } = new List<ViewEmpleadoDTO>();

    public virtual ICollection<ViewPuntoDeVentaDTO> PuntosDeVentas { get; set; } = new List<ViewPuntoDeVentaDTO>();
}

public record CreateSucursalDTO
{
    public string Nombre { get; set; } = null!;
    public string? Telefono { get; set; }
    public string Email { get; set; } = null!;
    public string Domicilio { get; set; } = null!;
    public string Ciudad { get; set; } = null!;

    public int IdTienda { get; set; }
}

public record ViewSucursalDTO
{
    public int IdSucursal { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Telefono { get; set; }
    public string Email { get; set; } = null!;
    public string Domicilio { get; set; } = null!;
    public string Ciudad { get; set; } = null!;

    public int IdTienda { get; set; }
}
