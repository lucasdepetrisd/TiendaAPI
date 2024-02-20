using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record ColorDTO
{
    public int IdColor { get; set; }

    public string Nombre { get; set; } = null!;
}
