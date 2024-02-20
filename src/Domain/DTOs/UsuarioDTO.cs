using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record UsuarioDTO
{
    [Key]
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public SesionDTO? Sesion { get; set; }

    public int? IdRol { get; set; }
    public virtual RolDTO? Rol { get; set; }

    public int IdEmpleado { get; set; }
    public virtual EmpleadoDTO Empleado { get; set; } = null!;

    //public virtual ICollection<VentaDTO> Ventas { get; set; } = new List<VentaDTO>();
}
