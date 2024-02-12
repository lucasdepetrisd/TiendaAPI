using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Inventario
{
    public int Cantidad { get; set; }

    public int IdSucursal { get; set; }

    public int Codigo { get; set; }

    public int IdColor { get; set; }

    public int IdMedida { get; set; }

    public int IdInventarioArticulo { get; set; }

    public virtual Articulo CodigoNavigation { get; set; } = null!;

    public virtual Color IdColorNavigation { get; set; } = null!;

    public virtual Talle IdMedidaNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<LineaDeVenta> LineaDeVenta { get; set; } = new List<LineaDeVenta>();
}
