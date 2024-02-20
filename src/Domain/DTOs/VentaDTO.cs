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
    public decimal Monto { get; set; }
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }

    public virtual ViewPagoDTO? Pago { get; set; }
    public virtual ComprobanteDTO? Comprobante { get; set; }
    
    public virtual ViewTipoDeComprobanteDTO TipoDeComprobante { get; set; } = null!;
    public virtual ViewClienteDTO Cliente { get; set; } = null!;
    public virtual ViewUsuarioDTO Usuario { get; set; } = null!;
    public virtual ViewPuntoDeVentaDTO PuntoDeVenta { get; set; } = null!;
    public virtual ICollection<LineaDeVentaDTO> LineasDeVentas { get; set; } = new List<LineaDeVentaDTO>();
}

public record CreateVentaDTO
{
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }

    public int IdCliente { get; set; }
    public int IdUsuario { get; set; }
    public int IdTipoDeComprobante { get; set; }
    public int IdPuntoVenta { get; set; }
}

public record ViewVentaDTO
{
    public int IdVenta { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }

    public virtual ViewPagoDTO? Pago { get; set; }
    public virtual ComprobanteDTO? Comprobante { get; set; }

    public int IdCliente { get; set; }
    public int IdUsuario { get; set; }
    public int IdTipoDeComprobante { get; set; }
    public int IdPuntoVenta { get; set; }
}
