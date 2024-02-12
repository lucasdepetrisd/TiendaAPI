using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Empleado
{
    public int LegajoEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdSucursal { get; set; }

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> UsuarioNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
