﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

// TODO: Plantear conversion a Complex Value Object
public partial class CondicionTributaria
{
    [Key]
    public int IdCondicionTributaria { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Tienda? Tienda { get; set; }

    public int IdTipoDeComprobante { get; set; }
    [ForeignKey("IdTipoDeComprobante")]
    public virtual TipoDeComprobante TipoDeComprobante { get; set; } = null!;
    //public virtual ICollection<TipoDeComprobante> TipoDeComprobante { get; set; } = new List<TipoDeComprobante>();
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}