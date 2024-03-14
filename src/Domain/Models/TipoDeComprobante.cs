using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class TipoDeComprobante
{
    [Key]
    public int IdTipoDeComprobante { get; set; }

    public string Nombre { get; private set; } = null!;

    public IdCondicionTributaria IdCondicionTributariaEmisor { get; set; }
    public CondicionTributaria CondicionTributariaEmisor { get; set; } = null!;

    public IdCondicionTributaria IdCondicionTributariaReceptor { get; set; }
    public CondicionTributaria CondicionTributariaReceptor { get; set; } = null!;

    public virtual ICollection<Venta> Ventas { get; set; } = [];

    public TipoDeComprobante()
    {
    }

    public TipoDeComprobante(CondicionTributaria emisor, CondicionTributaria? receptor)
    {
        CondicionTributariaEmisor = emisor;
        CondicionTributariaReceptor = receptor;

        Nombre = ObtenerNombre();
    }

    private string ObtenerNombre()
    {
        switch (CondicionTributariaEmisor.Nombre)
        {
            case "ResponsableInscripto":
                switch (CondicionTributariaReceptor.Nombre)
                {
                    case "ResponsableInscripto":
                    case "Monotributista":
                        Nombre = "Factura A";
                        break;
                    case "Exento":
                    case "ConsumidorFinal":
                    case "NoResponsable":
                        Nombre = "Factura B";
                        break;
                    default:
                        throw new InvalidOperationException("Condición Receptor Inválida. Debe ser RI, M, E, CF o NR.");
                }
                break;
            case "Monotributista":
            case "Exento":
                switch (CondicionTributariaReceptor.Nombre)
                {
                    case "ResponsableInscripto":
                    case "Monotributista":
                        Nombre = "Factura C";
                        break;
                    case "Exento":
                    case "ConsumidorFinal":
                    case "NoResponsable":
                        Nombre = "Factura C";
                        break;
                    default:
                        throw new InvalidOperationException("Condición Receptor Inválida. Debe ser RI, M, E, CF o NR.");
                }
                break;
            default:
                throw new InvalidOperationException("Condición Emisor Inválida. Debe ser RI, M o E.");
        }
        return Nombre;
    }
}
