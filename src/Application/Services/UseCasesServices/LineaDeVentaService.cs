using Application.Contracts.UseCasesServices;
using Application.DTOs.Ventas;
using Application.Services.ViewServices;
using AutoMapper;
using Domain.Models.Ventas;
using Domain.Repositories;

namespace Application.Services.UseCasesServices
{
    public class LineaDeVentaService : ViewService<LineaDeVenta, LineaDeVentaDTO>, ILineaDeVentaService
    {
        public LineaDeVentaService(
            ICrudRepository<LineaDeVenta> lineaDeVentaRepository,
            IMapper mapper) : base(lineaDeVentaRepository, mapper)
        {
        }
    }
}
