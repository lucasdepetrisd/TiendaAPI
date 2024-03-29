﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Articulo;

public partial class Articulo
{
    [Key]
    public int IdArticulo { get; set; }
    public string Codigo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;

    [Precision(18, 2)]
    public decimal PorcentajeIVA { get; set; } = 21;

    [Precision(18, 2)]
    public decimal Costo { get; set; }
    [Precision(18, 2)]
    public decimal MargenGanancia { get; set; }

    public int? IdCategoria { get; set; }
    [ForeignKey("IdCategoria")]
    public virtual Categoria? Categoria { get; set; }

    public int? IdMarca { get; set; }
    [ForeignKey("IdMarca")]
    public virtual Marca? Marca { get; set; }

    public int? IdTipoTalle { get; set; }
    [ForeignKey("IdTipoTalle")]
    public virtual TipoTalle? TipoTalle { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = [];
}
