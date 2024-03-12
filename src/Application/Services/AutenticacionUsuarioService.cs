using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class AutenticacionUsuarioService : IAutenticacionUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICrudRepository<Sesion> _sesionRepository;
        private readonly ICrudRepository<PuntoDeVenta> _puntoDeVentaRepository;
        private readonly IMapper _mapper;

        public AutenticacionUsuarioService(IUsuarioRepository usuarioRepository, ICrudRepository<Sesion> sesionRepository, ICrudRepository<PuntoDeVenta> puntoDeVentaRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _sesionRepository = sesionRepository;
            _puntoDeVentaRepository = puntoDeVentaRepository;
            _mapper = mapper;
        }

        public async Task<SesionDTO?> IniciarSesion(int puntoDeVentaId, string nombreUsuario, string contraseña)
        {
            var usuario = await _usuarioRepository.GetByUsernameAsync(nombreUsuario);
            var puntoDeVenta = await _puntoDeVentaRepository.GetByIdAsync(puntoDeVentaId) ?? throw new InvalidOperationException($"Punto de Venta con ID {puntoDeVentaId} no existente.");

            if (usuario == null || !VerifyPassword(usuario, contraseña))
            {
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
            }
            else if (usuario.Empleado.Sucursal.IdSucursal != puntoDeVenta.Sucursal.IdSucursal)
            {
                throw new InvalidOperationException($"Usuario {nombreUsuario} no pertenece a un empleado de la Sucursal {puntoDeVenta.Sucursal.Nombre}.");
            }
            else if (!puntoDeVenta.Habilitado)
            {
                throw new InvalidOperationException($"Punto de Venta {puntoDeVenta.IdPuntoDeVenta} no habilitado.");
            }

            // Chequeo que exista alguna sesion sin fecha de fin
            var sesionActiva = usuario.Sesiones.FirstOrDefault(s => s.FechaFin == null);
            if (sesionActiva != null)
            {
                // Hay una sesion abierta asi que la cerramos
                await CerrarSesion(sesionActiva.IdSesion);
            }

            var nuevaSesion = new Sesion
            {
                Usuario = usuario,
                PuntoDeVenta = puntoDeVenta,
                FechaInicio = DateTime.UtcNow
            };

            await _sesionRepository.AddAsync(nuevaSesion);

            var nuevaSesionDTO = _mapper.Map<SesionDTO>(nuevaSesion);

            return nuevaSesionDTO;
        }

        public async Task<SesionDTO?> CerrarSesion(int sesionId)
        {
            var sesion = await _sesionRepository.GetByIdAsync(sesionId);

            if (sesion != null)
            {
                sesion.FechaFin = DateTime.UtcNow;

                await _sesionRepository.UpdateAsync(sesion);

                var sesionDTO = _mapper.Map<SesionDTO>(sesion);

                return sesionDTO;
            }

            return null;
        }

        private bool VerifyPassword(Usuario usuario, string password)
        {
            return usuario.Contraseña == password;
        }
    }
}
