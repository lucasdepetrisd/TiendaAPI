using Application.Contracts.ExternalServices;
using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.DTOs.Ventas;
using Application.Services.ViewServices;
using Application.ServicioExternoAfip;
using AutoMapper;
using Domain.Models.Ventas;
using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
using Comprobante = Domain.Models.Ventas.Comprobante;

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

        public async Task<Venta> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta)
        {
            bool statusTarjeta = await _autorizacionTarjetaService.AutorizarTarjeta(venta, datosTarjeta);
            if (statusTarjeta == false)
            {
                throw new Exception("No se pudo autorizar la tarjeta.");
            }

            var pago = new Pago("Pendiente", venta, "Pago en Tarjeta");

            var (statusAfip, nroCompobante, nroCae) = await _autorizacionAfipService.AutorizarAfip(pago);

            if (statusAfip == false)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }

            if (nroCompobante == null)
            {
                nroCompobante = 0;
            }

            if (nroCae.IsNullOrEmpty())
            {
                nroCae = "";
            }

            venta.Comprobante = new Comprobante(nroCompobante.Value, venta.IdVenta);

            venta.Pago = pago;
            pago.Finalizar(venta, nroCae!);

            venta.Pago = pago;

            return venta;
        }

        public async Task<Venta> ProcesarPagoEnEfectivo(Venta venta)
        {
            var pago = new Pago("Pendiente", venta, "Pago en Efectivo");

            var (statusAfip, nroCompobante, nroCae) = await _autorizacionAfipService.AutorizarAfip(pago);

            if (statusAfip == false)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }

            if (nroCompobante == null)
            {
                nroCompobante = 0;
            }

            if (nroCae.IsNullOrEmpty())
            {
                nroCae = "";
            }

            venta.Comprobante = new Comprobante(nroCompobante.Value, venta.IdVenta);

            venta.Pago = pago;
            pago.Finalizar(venta, nroCae!);

            venta.Pago = pago;

            return venta;
        }
    }
}
