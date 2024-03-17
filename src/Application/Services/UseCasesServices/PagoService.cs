using Application.Contracts.ExternalServices;
using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.DTOs.Ventas;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Ventas;
using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.UseCasesServices
{
    public class PagoService : ViewService<Pago, PagoDTO>, IPagoService
    {
        private readonly IAutorizacionAfipService _autorizacionAfipService;
        private readonly IAutorizacionTarjetaService _autorizacionTarjetaService;

        public PagoService(
            ICrudRepository<Pago> pagoRepository,
            IMapper mapper,
            IAutorizacionTarjetaService autorizacionTarjetaService,
            IAutorizacionAfipService autorizacionAfipService) : base(pagoRepository, mapper)
        {
            _autorizacionTarjetaService = autorizacionTarjetaService;
            _autorizacionAfipService = autorizacionAfipService;
        }

        public async Task<(Pago pago, long nroComprobante)> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta)
        {
            bool statusTarjeta = await _autorizacionTarjetaService.AutorizarTarjeta(venta, datosTarjeta);
            if (statusTarjeta == false)
            {
                throw new Exception("No se pudo autorizar la tarjeta.");
            }

            var pago = new Pago(venta, "Pago en Tarjeta");

            var (statusAfip, nroComprobante, nroCae) = await _autorizacionAfipService.AutorizarAfip(pago);

            if (!statusAfip)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }

            if (nroComprobante == null)
            {
                nroComprobante = 0;
            }

            if (nroCae.IsNullOrEmpty())
            {
                nroCae = "";
            }

            pago.Finalizar(nroCae!);

            return (pago, nroComprobante.Value);
        }

        public async Task<(Pago pago, long nroComprobante)> ProcesarPagoEnEfectivo(Venta venta)
        {
            var pago = new Pago(venta, "Pago en Efectivo");

            var (statusAfip, nroComprobante, nroCae) = await _autorizacionAfipService.AutorizarAfip(pago);

            if (!statusAfip)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }

            if (nroComprobante == null)
            {
                nroComprobante = 0;
            }

            if (nroCae.IsNullOrEmpty())
            {
                nroCae = "";
            }

            pago.Finalizar(nroCae!);

            return (pago, nroComprobante.Value);
        }
    }
}
