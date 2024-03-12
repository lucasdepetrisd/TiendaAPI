using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public int Ticket { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;
}
