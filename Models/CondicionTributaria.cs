using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class CondicionTributaria
{
    public int IdCondicionTributaria { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    public virtual ICollection<Tienda> Tienda { get; set; } = new List<Tienda>();

    public virtual ICollection<TipoDeComprobante> TipoDeComprobante { get; set; } = new List<TipoDeComprobante>();
}
