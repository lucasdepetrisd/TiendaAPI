using Application.ServicioExternoAfip;

namespace Application.Services.HelperServices
{
    internal static class AutorizacionAfipHelpers
    {
        internal static (TipoDocumento tipo, long nro) ObtenerTipoYNumeroDocumento(string tipoDocumento, string numeroDocumento)
        {
            if (tipoDocumento == null)
            {
                throw new ArgumentNullException(nameof(tipoDocumento));
            }

            long parsedNumeroDocumento = 0;

            switch (tipoDocumento.ToLowerInvariant())
            {
                case "consumidorfinal":
                    return (TipoDocumento.ConsumidorFinal, 0);

                case "dni":
                    if (!string.IsNullOrEmpty(numeroDocumento))
                    {
                        if (!long.TryParse(numeroDocumento, out parsedNumeroDocumento))
                        {
                            throw new ArgumentException("Número de Documento inválido");
                        }
                        if (numeroDocumento.Length != 7 && numeroDocumento.Length != 8)
                        {
                            throw new ArgumentException("Número de DNI inválido.");
                        }
                    }
                    return (TipoDocumento.Dni, parsedNumeroDocumento);

                case "cuit":
                case "cuil":
                    if (!string.IsNullOrEmpty(numeroDocumento))
                    {
                        numeroDocumento = numeroDocumento.Replace("-", "");
                        if (!long.TryParse(numeroDocumento, out parsedNumeroDocumento))
                        {
                            throw new ArgumentException("Número de Documento inválido");
                        }
                        if (numeroDocumento.Length != 11)
                        {
                            throw new ArgumentException("Número de CUIT/CUIL inválido.");
                        }
                    }
                    return (tipoDocumento.ToLowerInvariant() switch
                    {
                        "cuit" => TipoDocumento.Cuit,
                        "cuil" => TipoDocumento.Cuit,
                        _ => throw new ArgumentException("Tipo de Documento inválido."),
                    }, parsedNumeroDocumento);

                default:
                    throw new ArgumentException("Tipo de Documento inválido.");
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
    }
}