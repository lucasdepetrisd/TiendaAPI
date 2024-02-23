using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record SesionDTO
{
    public int IdSesion { get; init; }
    public DateTime FechaInicio { get; init; }
    public DateTime? FechaFin { get; init; }

    public virtual ViewUsuarioDTO Usuario { get; init; } = null!;
    
    public virtual ViewPuntoDeVentaDTO PuntoDeVenta { get; init; } = null!;
}

public record CreateSesionDTO
{
    public DateTime FechaInicio { get; init; }
    [DefaultValue(null)]
    public DateTime? FechaFin { get; init; } = null;

    public int IdUsuario { get; init; }

    public int IdPuntoDeVenta { get; init; }
}

public record ViewSesionDTO
{
    public int IdSesion { get; init; }
    public DateTime FechaInicio { get; init; }
    public DateTime? FechaFin { get; init; }

    public int IdUsuario;

    public int IdPuntoDeVenta;
}
