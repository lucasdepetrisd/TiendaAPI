using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Cliente
{
    public int Dni { get; set; }

    public int Cuil { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public int IdCondicionTributaria { get; set; }

    public virtual CondicionTributaria IdCondicionTributariaNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
