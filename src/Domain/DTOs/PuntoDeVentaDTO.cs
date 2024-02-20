using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record PuntoDeVentaDTO
{
    public int IdPuntoDeVenta { get; set; }
    public int NumeroPtoVenta { get; set; }
    public bool Habilitado { get; set; }

    public virtual ViewSucursalDTO Sucursal { get; set; } = null!;

    public virtual ICollection<ViewSesionDTO> Sesiones { get; set; } = new List<ViewSesionDTO>();
    public virtual ICollection<ViewVentaDTO> Ventas { get; set; } = new List<ViewVentaDTO>();
}

public record CreatePuntoDeVentaDTO
{
    public int NumeroPtoVenta { get; set; }
    public bool Habilitado { get; set; }

    public int IdSucursal { get; set; }
}

public record ViewPuntoDeVentaDTO
{
    public int IdPuntoDeVenta { get; set; }
    public int NumeroPtoVenta { get; set; }
    public bool Habilitado { get; set; }

    public int IdSucursal { get; set; }
}
