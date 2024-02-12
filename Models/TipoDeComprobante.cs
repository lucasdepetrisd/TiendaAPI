using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class TipoDeComprobante
{
    public int IdTipoDeComprobante { get; set; }

    public int IdCondicionTributaria { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual CondicionTributaria IdCondicionTributariaNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
