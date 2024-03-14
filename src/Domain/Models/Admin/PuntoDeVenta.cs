using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Ventas;

namespace Domain.Models.Admin;

public partial class PuntoDeVenta
{
    [Key]
    public int IdPuntoDeVenta { get; set; }

    public int NumeroPtoVenta { get; set; }
    public bool Habilitado { get; set; }

    public int IdSucursal { get; set; }
    [ForeignKey("IdSucursal")]
    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual ICollection<Sesion> Sesiones { get; set; } = [];
    public virtual ICollection<Venta> Ventas { get; set; } = [];
}
