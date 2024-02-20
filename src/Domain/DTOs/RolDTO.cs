using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record RolDTO
{
    public int IdRol { get; set; }
    public string? Descripcion { get; set; }

    public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
}

public record CreateRolDTO
{
    public string? Descripcion { get; set; }
}

public record ViewRolDTO
{
    public int IdRol { get; set; }
    public string? Descripcion { get; set; }
}
