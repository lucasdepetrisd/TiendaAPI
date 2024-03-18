using Application.Contracts.ExternalServices;
using Application.Services.HelperServices;
using Application.ServicioExternoAfip;
using Domain.Models.Admin;
using Domain.Models.Ventas;
using Microsoft.Extensions.Options;

namespace Application.Services.ExternalServices
{
    public class AutorizacionAfipService : IAutorizacionAfipService
    {
        private readonly AutorizacionAfipSettings _afipSettings;
        private readonly ILoginService _afipAuthService;
        private readonly string? _codigoGrupo;
        private readonly decimal _afipLimiteNominal;
        private string? _afipToken;
        private DateTime _tokenExpiration;

        public AutorizacionAfipService(
            IOptionsSnapshot<AutorizacionAfipSettings> namedOptionsAccessor,
            ILoginService loginService)
        {
            _afipAuthService = loginService;

            _afipSettings = namedOptionsAccessor.Value;

            if (_afipSettings == null)
            {
                throw new ArgumentNullException(nameof(_afipSettings.codigoGrupo), "Afip Settings cannot be null or empty.");
            }
            else if (string.IsNullOrEmpty(_afipSettings?.codigoGrupo))
            {
                throw new ArgumentNullException(nameof(_afipSettings.codigoGrupo), "Codigo Grupo cannot be null or empty.");
            }
            else if (_afipSettings?.montoLimiteNominal == null)
            {
                throw new ArgumentNullException(nameof(_afipSettings.montoLimiteNominal), "Monto Limite Nominal cannot be null or empty.");
            }

            _codigoGrupo = _afipSettings.codigoGrupo;
            _afipLimiteNominal = _afipSettings.montoLimiteNominal;
            _afipToken = null;
            _tokenExpiration = DateTime.MinValue;
        }

        public async Task<(bool, long?, string?)> AutorizarAfip(Pago pago)
        {
            if (pago.Venta == null || pago.Venta.Cliente == null)
            {
                throw new ArgumentException("Pago debe tener una venta asociada con sus propiedades cargadas.");
            }

            Venta venta = pago.Venta;

            if (pago.MontoTotal > _afipLimiteNominal)
            {
                // Si supera el limite de la compra y es el cliente por defecto entonces deberá agregar un cliente
                if (venta.Cliente != null && venta.Cliente.IdCliente == 0)
                {
                    throw new InvalidOperationException("Monto máximo de AFIP para comprobante anónimo alcanzado. Agregue un cliente a la venta para continuar.");
                }
            }

            await ActualizarTokenAfip();

            var (ultimoNroFacA, ultimoNroFacB) = await ObtenerUltimoNumeroComprobante();

            TipoComprobante tipoComprobante = AutorizacionAfipHelpers.ObtenerTipoComprobante(venta.TipoDeComprobante?.Nombre);

            long nroComprobante = tipoComprobante switch
            {
                TipoComprobante.FacturaA => ultimoNroFacA + 1,
                TipoComprobante.FacturaB => ultimoNroFacB + 1,
                _ => throw new InvalidOperationException("Tipo de Comprobante inválido")
            };

            Cliente cliente = venta.Cliente;

            var (tipoDocumento, nroDocumento) = AutorizacionAfipHelpers.ObtenerTipoYNumeroDocumento(cliente.TipoDocumento, cliente.NroDocumento);

            var solicitud = new SolicitudAutorizacion
            {
                Fecha = pago.Fecha,
                ImporteTotal = (double)venta.Monto,
                ImporteNeto = (double)venta.MontoNetoGravado,
                ImporteIva = (double)venta.MontoIVA,
                Numero = nroComprobante,

                NumeroDocumento = nroDocumento,
                TipoDocumento = tipoDocumento,
                TipoComprobante = tipoComprobante
            };

            var result = await _afipAuthService.SolicitarCaeAsync(_afipToken, solicitud);

            if (!string.IsNullOrEmpty(result.Error) && result.Estado != EstadoSolicitud.Aprobada)
            {
                return (false, null, null);
            }
            else
            {
                return (true, nroComprobante, result.Cae);
            }
        }

        private async Task<(int facturaANumero, int facturaBNumero)> ObtenerUltimoNumeroComprobante()
        {
            await ActualizarTokenAfip();

            var ultimoComprobante = await _afipAuthService.SolicitarUltimosComprobantesAsync(_afipToken);

            int facturaANumber = ultimoComprobante.Comprobantes.FirstOrDefault(c => c.Id == (int)TipoComprobante.FacturaA)?.Numero ?? 0;
            int facturaBNumber = ultimoComprobante.Comprobantes.FirstOrDefault(c => c.Id == (int)TipoComprobante.FacturaB)?.Numero ?? 0;

            return (facturaANumber, facturaBNumber);
        }

        private async Task ActualizarTokenAfip()
        {
            if (string.IsNullOrEmpty(_afipToken) || DateTime.Now.AddMinutes(5) >= _tokenExpiration)
            {
                var autorizacion = await _afipAuthService.SolicitarAutorizacionAsync(_codigoGrupo);

                if (autorizacion != null)
                {
                    _afipToken = autorizacion.Token;
                    _tokenExpiration = autorizacion.Vencimiento;
                }
                else
                {
                    throw new InvalidOperationException("Failed to obtain AFIP token.");
                }
            }
        }
    }

    public class AutorizacionAfipSettings
    {
        public const string AutorizacionAfip = "AutorizacionAfip";

        public string codigoGrupo { get; set; } = string.Empty;
        public int montoLimiteNominal { get; set; }
    }
}