using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class PuntoDeVenta
{
    [Key]
    public int IdPuntoDeVenta { get; set; }

    public int NumeroPtoVenta { get; set; }
    public bool Habilitado { get; set; }

    public int IdSucursal { get; set; }
    [ForeignKey("IdSucursal")]
    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();
    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
