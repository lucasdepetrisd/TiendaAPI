using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class TipoDeComprobante
{
    [Key]
    public int IdTipoDeComprobante { get; set; }

    public string Nombre { get; private set; } = null!;

    public int IdCondicionTributariaEmisor { get; set; }
    public CondicionTributaria Emisor { get; set; } = null!;

    public int IdCondicionTributariaReceptor { get; set; }
    public CondicionTributaria Receptor { get; set; } = null!;

    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    public TipoDeComprobante()
    {
    }

    public TipoDeComprobante(CondicionTributaria emisor, CondicionTributaria receptor)
    {
        Emisor = emisor;
        Receptor = receptor;

        Nombre = ObtenerNombre();
    }

    private string ObtenerNombre()
    {
        switch (Emisor.Nombre)
        {
            case TipoCondicionTributaria.ResponsableInscripto:
                switch (Receptor.Nombre)
                {
                    case TipoCondicionTributaria.ResponsableInscripto:
                    case TipoCondicionTributaria.Monotributista:
                        Nombre = "Factura A";
                        break;
                    case TipoCondicionTributaria.Exento:
                    case TipoCondicionTributaria.ConsumidorFinal:
                    case TipoCondicionTributaria.NoResponsable:
                        Nombre = "Factura B";
                        break;
                    default:
                        throw new InvalidOperationException("Condición Emisor Invalida. Debe ser RI, M, E, CF o NR.");
                }
                break;
            case TipoCondicionTributaria.Monotributista:
            case TipoCondicionTributaria.Exento:
                switch (Receptor.Nombre)
                {
                    case TipoCondicionTributaria.ResponsableInscripto:
                    case TipoCondicionTributaria.Monotributista:
                        Nombre = "Factura C";
                        break;
                    case TipoCondicionTributaria.Exento:
                    case TipoCondicionTributaria.ConsumidorFinal:
                    case TipoCondicionTributaria.NoResponsable:
                        Nombre = "Factura C";
                        break;
                    default:
                        throw new InvalidOperationException("Condición Emisor Invalida. Debe ser RI, M, E, CF o NR.");
                }
                break;
            default:
                throw new InvalidOperationException("Condición Emisor Invalida. Debe ser RI, M o E.");

        }
        return Nombre;
    }
}
