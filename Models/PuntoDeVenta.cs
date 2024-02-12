using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class PuntoDeVenta
{
    public int NumeroPtoVenta { get; set; }

    public int IdSucursal { get; set; }

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
