using Application.ServicioExternoAfip;

namespace Application.Services.HelperServices
{
    internal static class AutorizacionAfipHelpers
    {
        internal static long ObtenerNroDocumento(string? tipoDocumento, string? numeroDocumento)
        {
            long parsedNumeroDocumento;
            if (!long.TryParse(numeroDocumento, out parsedNumeroDocumento))
            {
                throw new ArgumentException("Invalid numeroDocumento");
            }

            switch (tipoDocumento?.ToLowerInvariant())
            {
                case "ConsumidorFinal":
                    return parsedNumeroDocumento;
                case "dni":
                    if (numeroDocumento.Trim().Length != 7 && numeroDocumento.Trim().Length != 8)
                        throw new ArgumentException("Invalid DNI number");
                    return parsedNumeroDocumento;
                case "cuit":
                case "cuil":
                    if (numeroDocumento.Trim().Length != 11)
                        throw new ArgumentException("Invalid CUIT/CUIL number");
                    return parsedNumeroDocumento;
                default:
                    throw new ArgumentException("Invalid tipoDocumento");
            }
        }

        internal static TipoComprobante ObtenerTipoComprobante(string? nombreTipoComprobante)
        {
            switch (nombreTipoComprobante?.ToLowerInvariant())
            {
                case "factura a":
                    return TipoComprobante.FacturaA;
                case "factura b":
                    return TipoComprobante.FacturaB;
                default:
                    throw new ArgumentException("Invalid tipo de comprobante");
            }
        }

        internal static TipoDocumento ObtenerTipoDocumento(string? tipoDocumento)
        {
            switch (tipoDocumento.ToLowerInvariant())
            {
                case "cuit":
                    return TipoDocumento.Cuit;
                case "cuil":
                    return TipoDocumento.Cuil;
                case "dni":
                    return TipoDocumento.Dni;
                case "consumidorfinal":
                    return TipoDocumento.ConsumidorFinal;
                default:
                    throw new ArgumentException("Invalid tipoDocumento");
            }
        }
    }
}