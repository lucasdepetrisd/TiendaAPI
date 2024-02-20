using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record SesionDTO
{
    public int IdSesion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public virtual ViewUsuarioDTO Usuario { get; set; } = null!;
    
    public virtual ViewPuntoDeVentaDTO PuntoDeVenta { get; set; } = null!;
}

public record CreateSesionDTO
{
    public DateTime FechaInicio { get; set; }
    [DefaultValue(null)]
    public DateTime? FechaFin { get; set; } = null;

    public int IdUsuario { get; set; }

    public int IdPuntoDeVenta { get; set; }
}

public record ViewSesionDTO
{
    public int IdSesion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int IdUsuario;

    public int IdPuntoDeVenta;
}
