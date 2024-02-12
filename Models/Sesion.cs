using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Sesion
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; } = null!;

    public int IdPuntoDeVenta { get; set; }
    [ForeignKey("IdPuntoDeVenta")]
    public PuntoDeVenta PuntoDeVenta { get; set; } = null!;
}
