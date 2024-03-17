using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Ventas;

public partial class Pago
{
    [Key]
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    [Precision(18, 2)]
    public decimal MontoTotal { get; private set; }

    public string? NroCae { get; private set; } = null!;

    public EstadoPago Estado { get; private set; }

    public string? Observaciones { get; private set; }

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;

    private Pago() { }

    public Pago(Venta venta, string observacion = "")
    {
        Estado = EstadoPago.Pendiente;
        Fecha = DateTime.UtcNow;
        Observaciones = observacion;
        Venta = venta;
        MontoTotal = venta.Monto;
    }

    public void Finalizar(string nroCae, string observacion = "")
    {
        NroCae = nroCae;
        Estado = EstadoPago.Aprobado;

        if (observacion != "")
        {
            Observaciones = observacion;
        }
    }
}

public enum EstadoPago
{
    Pendiente = 0,
    Aprobado = 1,
    Rechazado = 2
}