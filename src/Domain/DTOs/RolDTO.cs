using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record RolDTO
{
    [Key]
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
}
