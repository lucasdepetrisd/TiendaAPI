using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int LegajoEmpleado { get; set; }

    public int IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Empleado LegajoEmpleadoNavigation { get; set; } = null!;
}
