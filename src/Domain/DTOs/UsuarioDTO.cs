using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record UsuarioDTO
{
    public int IdUsuario { get; init; }

    public string NombreUsuario { get; init; } = null!;

    public string Contraseña { get; init; } = null!;

    public virtual ViewSesionDTO? Sesion { get; init; }

    public virtual ViewRolDTO? Rol { get; init; }

    public virtual ViewEmpleadoDTO Empleado { get; init; } = null!;

    //public virtual ICollection<VentaDTO> Ventas { get; init; } = new List<VentaDTO>();
}

public record CreateUsuarioDTO
{
    public string NombreUsuario { get; init; } = null!;

    public string Contraseña { get; init; } = null!;

    public int IdRol { get; init; }

    public int IdEmpleado { get; init; }
}

public record ViewUsuarioDTO
{
    public int IdUsuario { get; init; }
    public string NombreUsuario { get; init; } = null!;
    public string Contraseña { get; init; } = null!;
    
    public int? IdSesion { get; init; }

    public int IdRol { get; init; }

    public int IdEmpleado { get; init; }

    //public virtual ICollection<VentaDTO> Ventas { get; init; } = new List<VentaDTO>();
}