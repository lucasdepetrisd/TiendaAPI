using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record SucursalDTO
{
    [Key]
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;
    public string? Telefono { get; set; }
    public string Email { get; set; } = null!;
    public string Domicilio { get; set; } = null!;
    public string Ciudad { get; set; } = null!;

    public int IdTienda { get; set; }
    public virtual TiendaDTO Tienda { get; set; } = null!;

    public virtual ICollection<EmpleadoDTO> Empleados { get; set; } = new List<EmpleadoDTO>();

    public virtual ICollection<PuntoDeVentaDTO> PuntosDeVentas { get; set; } = new List<PuntoDeVentaDTO>();
}
