using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Ventas;

public partial class Comprobante
{
    [Key]
    public int IdComprobante { get; set; }

    public long NroComprobante { get; set; }

    public string? NroTicket { get; private set; } = null!;

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;

    private Comprobante() { }

    public Comprobante(long nroCompobante, Venta venta)
    {
        NroComprobante = nroCompobante;
        Venta = venta;
        NroTicket = GenerarNroTicket();
    }

    private string GenerarNroTicket()
    {
        if (Venta == null || Venta.PuntoDeVenta == null)
        {
            return string.Empty;
        }

        // Obtengo el ID de la sucursal
        string sucursalId = Venta.PuntoDeVenta.IdSucursal.ToString().PadLeft(3, '0');

        // Obtengo el ID del pto de venta
        string ptoVentaNumber = Venta.IdPuntoVenta.ToString().PadLeft(3, '0');

        // Obtengo el NroComprobante obtenido de la AFIP
        string comprobanteNumber = NroComprobante.ToString().PadLeft(7, '0');

        return $"{sucursalId}-{ptoVentaNumber}-{comprobanteNumber}";
    }
}
