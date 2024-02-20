using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual Sesion? Sesion { get; set; }

    public int? IdRol { get; set; }
    [ForeignKey("IdRol")]
    public virtual Rol? Rol { get; set; }

    public int IdEmpleado { get; set; }
    [ForeignKey("IdEmpleado")]
    public virtual Empleado Empleado { get; set; } = null!;
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
