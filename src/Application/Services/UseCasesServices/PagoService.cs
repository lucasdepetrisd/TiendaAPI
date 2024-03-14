using Application.Contracts.ExternalServices;
using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.Services.ViewServices;
using Application.ServicioExternoAfip;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Comprobante = Domain.Models.Comprobante;

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

            var (statusAfip, nroCompobante) = await _autorizacionAfipService.AutorizarAfip(venta);
            if (statusAfip == false)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }
            
            if (nroCompobante == null)
            {
                throw new Exception("No se pudo obtener el último Nro de Comprobante de AFIP.");
            }

            var comprobante = new Comprobante(nroCompobante.Value, venta);

            var pago = new Pago("Aprobado", venta);

            venta.Pago = pago;
            venta.Comprobante = comprobante;

            // Save the Pago entity

            return venta;
        }

        public async Task<Venta> ProcesarPagoEnEfectivo(Venta venta)
        {
            var (statusAfip, nroCompobante) = await _autorizacionAfipService.AutorizarAfip(venta);
            if (statusAfip == false)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }

            if (nroCompobante == null)
            {
                throw new Exception("No se pudo obtener el último Nro de Comprobante de AFIP.");
            }

            var comprobante = new Comprobante(nroCompobante.Value, venta);

            var pago = new Pago("Aprobado", venta);

            venta.Pago = pago;
            venta.Comprobante = comprobante;

            // Save the Pago entity

            return venta;
        }
    }
}
