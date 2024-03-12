using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    public string NroDocumento { get; set; } = null!;
    public string TipoDocumento { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string Domicilio { get; set; } = null!;

    public IdCondicionTributaria? IdCondicionTributaria { get; set; }
    [ForeignKey("IdCondicionTributaria")]
    public virtual CondicionTributaria? CondicionTributaria { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; } = [];
}
