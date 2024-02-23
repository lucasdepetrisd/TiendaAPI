using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record PuntoDeVentaDTO
{
    public int IdPuntoDeVenta { get; init; }
    public int NumeroPtoVenta { get; init; }
    public bool Habilitado { get; init; }

    public virtual ViewSucursalDTO Sucursal { get; init; } = null!;

    public virtual ICollection<ViewSesionDTO> Sesiones { get; init; } = new List<ViewSesionDTO>();
    public virtual ICollection<ViewVentaDTO> Ventas { get; init; } = new List<ViewVentaDTO>();
}

public record CreatePuntoDeVentaDTO
{
    public int NumeroPtoVenta { get; init; }
    public bool Habilitado { get; init; }

    public int IdSucursal { get; init; }
}

public record ViewPuntoDeVentaDTO
{
    public int IdPuntoDeVenta { get; init; }
    public int NumeroPtoVenta { get; init; }
    public bool Habilitado { get; init; }

    public int IdSucursal { get; init; }
}
