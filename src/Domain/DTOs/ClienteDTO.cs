﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record ClienteDTO
{
    public int IdCliente { get; set; }
    public string Dni { get; set; } = null!;
    public string Cuil { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string Domicilio { get; set; } = null!;

    public int? IdCondicionTributaria { get; set; }
    [ForeignKey("IdCondicionTributaria")]
    public virtual CondicionTributariaDTO? CondicionTributaria { get; set; }

    public virtual ICollection<VentaDTO> Ventas { get; set; } = new List<VentaDTO>();
}