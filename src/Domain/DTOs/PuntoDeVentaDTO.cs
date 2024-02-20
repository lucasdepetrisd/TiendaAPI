using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record PuntoDeVentaDTO
{
    [Key]
    public int IdPuntoDeVenta { get; set; }

    public int NumeroPtoVenta { get; set; }
    public bool Habilitado { get; set; }

    public int IdSucursal { get; set; }
    public virtual SucursalDTO Sucursal { get; set; } = null!;

    public virtual ICollection<SesionDTO> Sesiones { get; set; } = new List<SesionDTO>();
    public virtual ICollection<VentaDTO> Ventas { get; set; } = new List<VentaDTO>();
}
