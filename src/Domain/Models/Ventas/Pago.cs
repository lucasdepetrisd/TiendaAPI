using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Domain.Models.Ventas;

public partial class Pago
{
    [Key]
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    [Precision(18, 2)]
    public decimal MontoTotal { get; private set; }

    public string? NroTicket { get; private set; } = null!;

    public string? NroCae { get; private set; } = null!;

    public string Estado { get; private set; } = null!;

    public string? Observaciones { get; private set; }

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;

    private Pago() { }

    public Pago(string estado, Venta venta, string? observacion = "")
    {
        Estado = estado;
        Fecha = DateTime.UtcNow;
        Observaciones = observacion;
        Venta = venta;
        MontoTotal = venta.Monto;
    }

    public void Finalizar(Venta venta, string nroCae, string observacion = "")
    {
        Venta = venta;
        NroTicket = GenerarNroTicket();
        NroCae = nroCae;
        Estado = "Aprobado";

        if (observacion != "")
        {
            Observaciones = observacion;
        }
    }

    private string GenerarNroTicket()
    {
        if (Venta == null || Venta.Comprobante == null || Venta.PuntoDeVenta == null)
        {
            return string.Empty;
        }

        // Obtengo el id de sucursal
        string sucursalId = Venta.PuntoDeVenta.IdSucursal.ToString().PadLeft(3, '0');

        // Obtengo NroComprobante
        string comprobanteNumber = Venta.Comprobante.NroComprobante.ToString().PadLeft(7, '0');

        return $"{sucursalId}-{comprobanteNumber}";
    }
}
