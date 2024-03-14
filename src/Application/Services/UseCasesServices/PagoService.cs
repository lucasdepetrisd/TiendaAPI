using Application.Contracts.ExternalServices;
using Application.Contracts.UseCasesServices;
using Application.DTOs;
using Application.Services.ViewServices;
using Application.ServicioExternoAfip;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

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
            ILoginService afipAuthService,
            IAutorizacionAfipService autorizacionAfipService) : base(pagoRepository, mapper)
        {
            _autorizacionTarjetaService = autorizacionTarjetaService;
            _autorizacionAfipService = autorizacionAfipService;
        }

        public async Task<bool> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta)
        {
            bool statusTarjeta = await _autorizacionTarjetaService.Autorizar(venta, datosTarjeta);
            if (statusTarjeta == false)
            {
                throw new Exception("No se pudo autorizar la tarjeta.");
            }

            bool statusAfip = await _autorizacionAfipService.AutorizarAfip(venta);
            if (statusAfip == false)
            {
                throw new Exception("No se pudo autorizar en AFIP.");

            }

            return statusAfip;
        }

        public async Task<bool> ProcesarPagoEnEfectivo(Venta venta)
        {
            bool statusAfip = await _autorizacionAfipService.AutorizarAfip(venta);

            if (statusAfip == false)
            {
                throw new Exception("No se pudo autorizar en AFIP.");
            }

            return statusAfip;
        }
    }
}
