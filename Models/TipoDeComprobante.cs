using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class TipoDeComprobante
{
    [Key]
    public int IdTipoDeComprobante { get; set; }

    public string Nombre { get; set; } = null!;

    /*public int IdCondicionTributaria { get; set; }
    [ForeignKey("IdCondicionTributaria")]
    public virtual CondicionTributaria CondicionTributaria { get; set; } = null!;*/
    //TODO: Añadir relación 1 a 1
    public virtual ICollection<CondicionTributaria> CondicionTributarias { get; set; } = new List<CondicionTributaria>();
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
