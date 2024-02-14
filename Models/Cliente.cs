using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    public int Dni { get; set; }
    public int Cuil { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string Domicilio { get; set; } = null!;

    public int? IdCondicionTributaria { get; set; }
    [ForeignKey("IdCondicionTributaria")]
    public virtual CondicionTributaria? CondicionTributaria { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
