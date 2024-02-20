using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record EmpleadoDTO
{
    public int IdEmpleado { get; set; }
    public int Legajo { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Email { get; set; }
    public string? Domicilio { get; set; }

    public virtual ViewSucursalDTO Sucursal { get; set; } = null!;

    public virtual ViewUsuarioDTO Usuario { get; set; } = null!;

    //public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}

public record CreateEmpleadoDTO
{
    public int Legajo { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Email { get; set; }
    public string? Domicilio { get; set; }

    public int IdSucursal { get; set; }

    //public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}

public record ViewEmpleadoDTO
{
    public int IdEmpleado { get; set; }
    public int Legajo { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Email { get; set; }
    public string? Domicilio { get; set; }

    public int IdSucursal { get; set; }

    //public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
