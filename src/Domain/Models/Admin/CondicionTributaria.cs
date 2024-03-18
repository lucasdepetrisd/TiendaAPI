using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Admin;

public partial class CondicionTributaria
{
    [Key]
    public IdCondicionTributaria IdCondicionTributaria { get; set; }

    public string Nombre
    {
        get
        {
            return IdCondicionTributaria.ToString();
        }
    }

    public virtual Tienda? Tienda { get; set; }

    /*public virtual ICollection<TipoDeComprobante> TiposDeComprobantesEmisor { get; set; } = new List<TipoDeComprobante>();
    public virtual ICollection<TipoDeComprobante> TiposDeComprobantesReceptor { get; set; } = new List<TipoDeComprobante>();*/
    public virtual ICollection<Cliente> Clientes { get; set; } = [];
}

public enum IdCondicionTributaria : int
{
    ResponsableInscripto = 0,
    Monotributista = 1,
    Exento = 2,
    NoResponsable = 3,
    ConsumidorFinal = 4
}
