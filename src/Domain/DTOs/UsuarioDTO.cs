using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record UsuarioDTO
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ViewSesionDTO? Sesion { get; set; }

    public virtual ViewRolDTO? Rol { get; set; }

    public virtual ViewEmpleadoDTO Empleado { get; set; } = null!;

    //public virtual ICollection<VentaDTO> Ventas { get; set; } = new List<VentaDTO>();
}

public record CreateUsuarioDTO
{
    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual SesionDTO? Sesion { get; set; }

    public int IdRol { get; set; }

    public int IdEmpleado { get; set; }
}

public record ViewUsuarioDTO
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Contraseña { get; set; } = null!;
    
    public virtual ViewSesionDTO? Sesion { get; set; }

    public virtual ViewRolDTO? Rol { get; set; }

    public virtual ViewEmpleadoDTO Empleado { get; set; } = null!;

    //public virtual ICollection<VentaDTO> Ventas { get; set; } = new List<VentaDTO>();
}