using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record EmpleadoDTO
{
    public int IdEmpleado { get; init; }
    public int Legajo { get; init; }
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Email { get; init; }
    public string? Domicilio { get; init; }

    public virtual ViewSucursalDTO Sucursal { get; init; } = null!;

    public virtual ViewUsuarioDTO Usuario { get; init; } = null!;

    //public virtual ICollection<Venta> Ventas { get; init; } = new List<Venta>();
}

public record CreateEmpleadoDTO
{
    public int Legajo { get; init; }
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Email { get; init; }
    public string? Domicilio { get; init; }

    public int IdSucursal { get; init; }

    //public virtual ICollection<Venta> Ventas { get; init; } = new List<Venta>();
}

public record ViewEmpleadoDTO
{
    public int IdEmpleado { get; init; }
    public int Legajo { get; init; }
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Email { get; init; }
    public string? Domicilio { get; init; }

    public int IdSucursal { get; init; }

    //public virtual ICollection<Venta> Ventas { get; init; } = new List<Venta>();
}
