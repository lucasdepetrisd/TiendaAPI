using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Empleado
{
    [Key]
    public int IdEmpleado { get; set; }

    public int Legajo { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Email { get; set; }
    public string? Domicilio { get; set; }

    public int IdSucursal { get; set; }
    [ForeignKey("IdSucursal")]
    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }

    //public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
