using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Admin;

public partial class Tienda
{
    [Key]
    public int IdTienda { get; set; }

    public string Cuit { get; set; } = null!;

    public IdCondicionTributaria IdCondicionTributaria { get; set; }
    [ForeignKey("IdCondicionTributaria")]
    public virtual CondicionTributaria CondicionTributaria { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursales { get; set; } = new List<Sucursal>();
}
