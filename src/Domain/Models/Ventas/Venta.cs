using Domain.Models.Admin;
using Domain.Models.Articulo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Ventas;

public partial class Venta
{
    [Key]
    public int IdVenta { get; private set; }

    public DateTime Fecha { get; private set; } = DateTime.UtcNow;

    public EstadoVenta Estado { get; private set; }

    public string? Observaciones { get; private set; } = "Ninguna";

    public decimal Monto
    {
        get
        {
            return CalcularTotal();
        }
    }

    public decimal MontoIVA
    {
        get
        {
            decimal totalIVA = 0;
            foreach (var lineaDeVenta in LineasDeVentas)
            {
                totalIVA += lineaDeVenta.MontoIVA;
            }
            return totalIVA;
        }
    }

    public decimal MontoNetoGravado
    {
        get
        {
            decimal totalNeto = 0;
            foreach (var lineaDeVenta in LineasDeVentas)
            {
                totalNeto += lineaDeVenta.NetoGravado;
            }
            return totalNeto;
        }
    }

    public virtual Pago? Pago { get; set; }
    public virtual Comprobante? Comprobante { get; set; }

    public int? IdCliente { get; private set; }
    [ForeignKey("IdCliente")]
    public virtual Cliente? Cliente { get; private set; }

    public int? IdTipoDeComprobante { get; set; }
    [ForeignKey("IdTipoDeComprobante")]
    public virtual TipoDeComprobante? TipoDeComprobante { get; set; }

    public int IdUsuario { get; private set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario Usuario { get; private set; } = null!;

    public int IdPuntoVenta { get; private set; }
    public virtual PuntoDeVenta PuntoDeVenta { get; private set; } = null!;

    public virtual ICollection<LineaDeVenta> LineasDeVentas { get; private set; } = [];

    private Venta() { }

    public Venta(Usuario usuario, PuntoDeVenta puntoDeVenta, Cliente cliente, CondicionTributaria condicionEmisor)
    {
        Usuario = usuario;
        Cliente = cliente;
        PuntoDeVenta = puntoDeVenta;
        TipoDeComprobante = new TipoDeComprobante(condicionEmisor, cliente.CondicionTributaria);
    }

    public void Cancelar() => AccionSiVentaEsPendiente(() => Estado = EstadoVenta.Cancelada, nameof(Cancelar));

    public void Finalizar(long nroComprobante)
    {
        AccionSiVentaEsPendiente(() =>
        {
            Estado = EstadoVenta.Finalizada;

            Comprobante = new Comprobante(nroComprobante, this);

        }, nameof(Finalizar));
    }

    public void AgregarPago(Pago pago)
    {
        AccionSiVentaEsPendiente(() =>
        {
            Pago = pago;

        }, "Agregar Pago");
    }

    public LineaDeVenta AgregarLineaDeVenta(int cantidad, Inventario inventario)
    {
        if (cantidad > inventario.Cantidad)
        {
            throw new InvalidOperationException($"Cantidad solicitada ({cantidad}) inválida. La cantidad solicitada excede la disponible en el inventario ({inventario.Cantidad}).");
        }
        else if (cantidad == 0)
        {
            throw new InvalidOperationException($"Cantidad solicitada ({cantidad}) inválida. Solicite una cantidad mayor a cero.");
        }

        if (PuntoDeVenta.IdSucursal != inventario.IdSucursal)
        {
            throw new InvalidOperationException($"No se puede agregar un inventario procedente de otra sucursal.");
        }

        LineaDeVenta lineaDeVenta = new LineaDeVenta(cantidad, inventario, this);
        lineaDeVenta.CalcularSubtotal();

        AccionSiVentaEsPendiente(() =>
        {
            LineasDeVentas.Add(lineaDeVenta);

        }, nameof(AgregarLineaDeVenta));

        return lineaDeVenta;
    }

    public void QuitarLineaDeVenta(int idLineaDeVenta)
    {
        AccionSiVentaEsPendiente(() =>
        {
            var lineaDeVenta = LineasDeVentas.FirstOrDefault(l => l.IdLineaDeVenta == idLineaDeVenta);

            if (lineaDeVenta != null)
            {
                LineasDeVentas.Remove(lineaDeVenta);
            }
            else
            {
                throw new InvalidOperationException("La línea de venta indicada no pertenece a esta venta.");
            }

        }, nameof(Finalizar));
    }

    private decimal CalcularTotal()
    {
        decimal monto;
        monto = 0;

        foreach (LineaDeVenta lineaDeVenta in LineasDeVentas)
        {
            monto += lineaDeVenta.Subtotal;
        }

        return monto;
    }

    public void ModificarCliente(Cliente cliente, CondicionTributaria condicionEmisor)
    {
        AccionSiVentaEsPendiente(() =>
        {
            Cliente = cliente;

            TipoDeComprobante = new TipoDeComprobante(condicionEmisor, cliente.CondicionTributaria);

        }, "Modificar");
    }

    // Función lambda
    private void AccionSiVentaEsPendiente(Action action, string actionType)
    {
        if (Estado != EstadoVenta.Pendiente)
        {
            throw new InvalidOperationException($"La venta solo se puede {actionType} si esta en estado \"Pendiente\". Estado actual: \"{Estado}\"");
        }

        action();
    }

    public bool PuedeFinalizar(out string errorMessage)
    {
        errorMessage = string.Empty;

        // Verificar si la venta está en estado "Pendiente"
        if (Estado != EstadoVenta.Pendiente)
        {
            errorMessage = "La venta no está en estado pendiente.";
            return false;
        }

        if (Monto <= 0)
        {
            errorMessage = "El monto total debe ser mayor a 0";
            return false;
        }

        // Verificar si la venta tiene al menos una línea de venta
        if (!LineasDeVentas.Any())
        {
            errorMessage = "La venta no tiene ninguna línea de venta.";
            return false;
        }

        // Verificar si todas las líneas de venta tienen inventarios válidos
        foreach (var lineaDeVenta in LineasDeVentas)
        {
            if (lineaDeVenta.Inventario == null)
            {
                errorMessage = $"El inventario con ID {lineaDeVenta.IdInventario} no fue encontrado.";
                return false;
            }
            else if (lineaDeVenta.Cantidad > lineaDeVenta.Inventario.Cantidad)
            {
                errorMessage = $"El inventario con ID {lineaDeVenta.IdInventario} no tiene suficiente cantidad.";
                return false;
            }
        }

        return true;
    }
}

public enum EstadoVenta
{
    Pendiente = 0,
    Finalizada = 1,
    Cancelada = 2
}