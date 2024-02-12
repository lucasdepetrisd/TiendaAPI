using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public int Cuit { get; set; }

    public virtual Tienda CuitNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> Empleado { get; set; } = new List<Empleado>();

    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();

    public virtual ICollection<PuntoDeVenta> PuntoDeVenta { get; set; } = new List<PuntoDeVenta>();
}
