using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Domain.Models;

public partial class Pago
{
    [Key]
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    [Precision(18, 2)]
    public decimal Monto
    {
        get
        {
            return Venta.CalcularTotal();
        }
    }

    public string NroTicket { get; private set; } = null!;

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;

    private Pago () { }

    public Pago (string estado, Venta venta)
    {
        Estado = estado;
        Fecha = DateTime.UtcNow;
        Venta = venta;
        NroTicket = GenerarNroTicket();
    }

    // Other properties and methods...

    private string GenerarNroTicket()
    {
        if (Venta.Comprobante == null || Venta.PuntoDeVenta == null)
        {
            throw new InvalidOperationException("No se puede generar el Ticket de pago. No se tienen los datos de Venta.");
        }

        // Obtengo el id de sucursal
        string sucursalId = Venta.PuntoDeVenta.IdSucursal.ToString().PadLeft(3, '0');

        // Obtengo NroComprobante
        string comprobanteNumber = Venta.Comprobante.NroComprobante.ToString().PadLeft(7, '0');

        return $"{sucursalId}-{comprobanteNumber}";
    }
}
