using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class VentaService : BaseService<Venta, CreateVentaDTO, VentaDTO>, IVentaService
    {
        private readonly IRepository<Venta> _ventaRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<PuntoDeVenta> _puntoDeVentaRepository;

        public VentaService(
            IRepository<Venta> ventaRepository,
            IRepository<Usuario> usuarioRepository,
            IRepository<PuntoDeVenta> puntoDeVentaRepository,
            IMapper mapper)
            : base(ventaRepository, mapper)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _usuarioRepository = usuarioRepository;
            _puntoDeVentaRepository = puntoDeVentaRepository;
        }

        public async Task<VentaDTO> IniciarVenta(int usuarioId, int puntoDeVentaId)
        {
            // Retrieve Usuario and PuntoDeVenta from repositories
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            var puntoDeVenta = await _puntoDeVentaRepository.GetByIdAsync(puntoDeVentaId);

            // Check if Usuario and PuntoDeVenta exist
            if (usuario == null || puntoDeVenta == null)
            {
                throw new InvalidOperationException("Usuario or PuntoDeVenta not found.");
            }

            // Create a new Venta entity
            var venta = new Venta(usuario, puntoDeVenta);

            // Add the Venta entity to the repository
            await _ventaRepository.AddAsync(venta);

            VentaDTO nuevaVenta = _mapper.Map<VentaDTO>(venta);

            return nuevaVenta;
        }
    }
}
