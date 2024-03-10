namespace Application.DTOs;

public record TarjetaDTO(
    string NumeroTarjeta,
    Titular Titular,
    string MesExpiracion,
    string AñoExpiracion,
    string CVV
);

public record Titular(
    string NombreCompleto,
    TipoDocumento TipoDocumento,
    string NroDocumento
);

public enum TipoDocumento
{
    Dni = 0,
    Cuil = 1
}