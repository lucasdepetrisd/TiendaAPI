using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record RolDTO
{
    public int IdRol { get; init; }
    public string? Descripcion { get; init; }

    public virtual ICollection<UsuarioDTO> Usuarios { get; init; } = new List<UsuarioDTO>();
}

public record CreateRolDTO
{
    public string? Descripcion { get; init; }
}

public record ViewRolDTO
{
    public int IdRol { get; init; }
    public string? Descripcion { get; init; }
}
