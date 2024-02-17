using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Sucursal
{
    [Key]
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;
    public string? Telefono { get; set; }
    public string Email { get; set; } = null!;
    public string Domicilio { get; set; } = null!;
    public string Ciudad { get; set; } = null!;

    public int IdTienda { get; set; }
    [ForeignKey("IdTienda")]
    public virtual Tienda Tienda { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<PuntoDeVenta> PuntosDeVentas { get; set; } = new List<PuntoDeVenta>();
}
