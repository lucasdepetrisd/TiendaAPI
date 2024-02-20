using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record SesionDTO
{
    [Key]
    public int IdSesion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int IdUsuario { get; set; }
    public virtual UsuarioDTO Usuario { get; set; } = null!;

    public int? IdPuntoDeVenta { get; set; }
    public virtual PuntoDeVentaDTO PuntoDeVenta { get; set; } = null!;
}
