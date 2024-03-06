using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

// TODO: Plantear conversion a Complex Value Object
public partial class CondicionTributaria
{
    [Key]
    public int IdCondicionTributaria { get; set; }

    public TipoCondicionTributaria Nombre { get; set; }

    public virtual Tienda? Tienda { get; set; }

    //public int IdTipoDeComprobante { get; set; }
    //[ForeignKey("IdTipoDeComprobante")]
    //public virtual TipoDeComprobante TipoDeComprobante { get; set; } = null!;
    public virtual ICollection<TipoDeComprobante> TiposDeComprobantesEmisor { get; set; } = new List<TipoDeComprobante>();
    public virtual ICollection<TipoDeComprobante> TiposDeComprobantesReceptor { get; set; } = new List<TipoDeComprobante>();
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}

public enum TipoCondicionTributaria
{
    ResponsableInscripto = 1,
    Monotributista = 2,
    Exento = 3,
    NoResponsable = 4,
    ConsumidorFinal = 5,
}
