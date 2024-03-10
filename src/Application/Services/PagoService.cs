using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class PagoService : BaseService<Pago, CreatePagoDTO, PagoDTO>, IPagoService
    {
        private readonly IAutorizacionTarjetaService _autorizacionTarjetaService;

        public PagoService(
            IRepository<Pago> pagoRepository,
            IMapper mapper,
            IAutorizacionTarjetaService autorizacionTarjetaService) : base(pagoRepository, mapper)
        {
            _autorizacionTarjetaService = autorizacionTarjetaService;
        }

        public async Task<bool> ProcesarPagoConTarjeta(Venta venta, TarjetaDTO datosTarjeta)
        {
            var status = await _autorizacionTarjetaService.Autorizar(venta, datosTarjeta);

            return status;
        }

        public Task<bool> ProcesarPagoEnEfectivo(Venta venta)
        {
            throw new NotImplementedException();
        }
    }
}
