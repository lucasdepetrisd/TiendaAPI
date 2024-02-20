using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record VentaDTO
{
    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    [Precision(18, 2)]
    public decimal Monto { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual PagoDTO? Pago { get; set; }
    public virtual ComprobanteDTO? Comprobante { get; set; }
    public virtual TipoDeComprobanteDTO TipoDeComprobante { get; set; } = null!;

    public int IdCliente { get; set; }
    public virtual ClienteDTO Cliente { get; set; } = null!;

    public int IdUsuario { get; set; }
    public virtual UsuarioDTO Usuario { get; set; } = null!;

    public int IdTipoDeComprobante { get; set; }

    public int IdPuntoVenta { get; set; }
    public virtual PuntoDeVentaDTO PuntoDeVenta { get; set; } = null!;

    public virtual ICollection<LineaDeVentaDTO> LineasDeVentas { get; set; } = new List<LineaDeVentaDTO>();
}
