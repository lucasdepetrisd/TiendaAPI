using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Inventario
{
    [Key]
    public int IdInventario { get; set; }

    public int Cantidad { get; set; }

    public int IdSucursal { get; set; }
    [ForeignKey("IdSucursal")]
    public virtual Sucursal Sucursal { get; set; } = null!;

    public int IdColor { get; set; }
    [ForeignKey("IdColor")]
    public virtual Color? Color { get; set; }
    
    public int IdTalle { get; set; }
    [ForeignKey("IdTalle")]
    public virtual Talle? Talle { get; set; }
    
    public int IdArticulo { get; set; }
    [ForeignKey("IdArticulo")]
    public virtual Articulo Articulo { get; set; } = null!;

    //public virtual ICollection<LineaDeVenta> LineaDeVenta { get; set; } = new List<LineaDeVenta>();
}
