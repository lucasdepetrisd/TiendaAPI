using Application.Contracts;
using Application.DTOs;
using Application.ServicioExternoAfip;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class PagoService : ViewService<Pago, PagoDTO>, IPagoService
    {
        private readonly IAutorizacionTarjetaService _autorizacionTarjetaService;
        private readonly ILoginService _afipAuthService;
        private readonly string? _codigoGrupo;
        private string? _afipToken;
        private DateTime _tokenExpiration;

        public PagoService(
            ICrudRepository<Pago> pagoRepository,
            IMapper mapper,
            IAutorizacionTarjetaService autorizacionTarjetaService,
            ILoginService afipAuthService) : base(pagoRepository, mapper)
        {
            _autorizacionTarjetaService = autorizacionTarjetaService;
            _afipAuthService = afipAuthService;
            _codigoGrupo = "8D91A105-0AC1-41EB-A6BB-D0554C977334"; //Mover a ENV Var
            _afipToken = null;
            _tokenExpiration = DateTime.MinValue;
        }

        public async Task<bool> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta)
        {
            var status = await _autorizacionTarjetaService.Autorizar(venta, datosTarjeta);

            return status;
        }

        public async Task<bool> ProcesarPagoEnEfectivo(Venta venta)
        {
            decimal afipLimite = 10000; //Convertir a ENV Var

            if (venta.CalcularTotal() > afipLimite)
            {
                // Si supera el limite de la compra y es el cliente por defecto entonces deberá agregar un cliente
                if (venta.Cliente != null && venta.Cliente.IdCliente == 0)
                {
                    throw new InvalidOperationException("Monto máximo de AFIP para comprobante anónimo alcanzado. Agregue un cliente a la venta para continuar.");
                }
            }

            await ActualizarTokenAfip();

            var (ultimoNroFacA, ultimoNroFacB) = await ObtenerUltimoNumeroComprobante();

            decimal totalNeto = 0;
            decimal totalIVA = 0;
            TipoComprobante tipoComprobante = ObtenerTipoComprobante(venta.TipoDeComprobante?.Nombre);

            long nroComprobante = tipoComprobante switch
            {
                TipoComprobante.FacturaA => ultimoNroFacA + 1,
                TipoComprobante.FacturaB => ultimoNroFacB + 1,
                _ => throw new InvalidOperationException("TipoComprobante inválido")
            };

            foreach (var lineaDeVenta in venta.LineasDeVentas)
            {
                totalNeto += lineaDeVenta.NetoGravado;
                totalIVA += lineaDeVenta.MontoIVA;
            }

            var solicitud = new SolicitudAutorizacion
            {
                Fecha = venta.Fecha,
                ImporteTotal = (double)venta.CalcularTotal(),
                ImporteNeto = (double)totalNeto,
                ImporteIva = (double)totalIVA,
                Numero = nroComprobante,

                NumeroDocumento = ObtenerNroDocumento(venta.Cliente?.TipoDocumento, venta.Cliente?.NroDocumento),
                TipoDocumento = ObtenerTipoDocumento(venta.Cliente?.TipoDocumento),
                TipoComprobante = ObtenerTipoComprobante(venta.TipoDeComprobante?.Nombre)
            };

            var result = await _afipAuthService.SolicitarCaeAsync(_afipToken, solicitud);

            if (!string.IsNullOrEmpty(result.Error) && result.Estado != EstadoSolicitud.Aprobada)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<(int facturaANumero, int facturaBNumero)> ObtenerUltimoNumeroComprobante()
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
                    throw new InvalidOperationException("Fallo al obtener el token de AFIP.");
                }
            }
        }

        private static long ObtenerNroDocumento(string? tipoDocumento, string? numeroDocumento)
        {
            long parsedNumeroDocumento;
            if (!long.TryParse(numeroDocumento, out parsedNumeroDocumento))
            {
                throw new ArgumentException("Número de Documento inválido");
            }

            switch (tipoDocumento?.ToLowerInvariant())
            {
                case "ConsumidorFinal":
                    return parsedNumeroDocumento;
                case "dni":
                    if (numeroDocumento.Trim().Length != 7 && numeroDocumento.Trim().Length != 8)
                        throw new ArgumentException("Número de DNI inválido");
                    return parsedNumeroDocumento;
                case "cuit":
                case "cuil":
                    if (numeroDocumento.Trim().Length != 11)
                        throw new ArgumentException("Número de CUIT/CUIL inválido");
                    return parsedNumeroDocumento;
                default:
                    throw new ArgumentException("Tipo de Documento inválido");
            }
        }

        private static ServicioExternoAfip.TipoDocumento ObtenerTipoDocumento(string? tipoDocumento)
        {
            switch (tipoDocumento.ToLowerInvariant())
            {
                case "cuit":
                    return ServicioExternoAfip.TipoDocumento.Cuit;
                case "cuil":
                    return ServicioExternoAfip.TipoDocumento.Cuil;
                case "dni":
                    return ServicioExternoAfip.TipoDocumento.Dni;
                case "consumidorfinal":
                    return ServicioExternoAfip.TipoDocumento.ConsumidorFinal;
                default:
                    throw new ArgumentException("Tipo de Documento inválido");
            }
        }

        private static TipoComprobante ObtenerTipoComprobante(string? nombreTipoComprobante)
        {
            switch (nombreTipoComprobante?.ToLowerInvariant())
            {
                case "factura a":
                    return TipoComprobante.FacturaA;
                case "factura b":
                    return TipoComprobante.FacturaB;
                default:
                    throw new ArgumentException("Tipo de comprobante inválido");
            }
        }
    }
}
