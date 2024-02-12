﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Sesion
{
    [Key]
    public int IdSesion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario? Usuario { get; set; }

    public int IdPuntoDeVenta { get; set; }
    [ForeignKey("IdPuntoDeVenta")]
    public virtual PuntoDeVenta? PuntoDeVenta { get; set; }
}
