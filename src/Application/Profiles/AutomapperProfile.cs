﻿using Application.DTOs.Admin;
using Application.DTOs.Admin.Articulo;
using Application.DTOs.Ventas;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Models.Articulo;
using Domain.Models.Ventas;

namespace Application.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //*---------------------Articulo------------------------*
            CreateMap<Articulo, ArticuloDTO>().ReverseMap();
            CreateMap<Articulo, CreateArticuloDTO>().ReverseMap();
            CreateMap<Articulo, ViewArticuloDTO>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CreateCategoriaDTO>().ReverseMap();
            CreateMap<Categoria, ViewCategoriaDTO>().ReverseMap();

            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Marca, CreateMarcaDTO>().ReverseMap();
            CreateMap<Marca, ViewMarcaDTO>().ReverseMap();

            CreateMap<TipoTalle, TipoTalleDTO>().ReverseMap();
            CreateMap<TipoTalle, CreateTipoTalleDTO>().ReverseMap();
            CreateMap<TipoTalle, ViewTipoTalleDTO>().ReverseMap();

            CreateMap<Talle, TalleDTO>().ReverseMap();
            CreateMap<Talle, CreateTalleDTO>().ReverseMap();
            CreateMap<Talle, ViewTalleDTO>().ReverseMap();

            CreateMap<Inventario, InventarioDTO>().ReverseMap();
            CreateMap<Inventario, CreateInventarioDTO>().ReverseMap();
            CreateMap<Inventario, ViewInventarioDTO>().ReverseMap();

            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<Color, CreateColorDTO>().ReverseMap();

            //*---------------------Admin------------------------*
            CreateMap<Tienda, TiendaDTO>().ReverseMap();
            CreateMap<Tienda, ViewTiendaDTO>().ReverseMap();

            CreateMap<Sucursal, SucursalDTO>().ReverseMap();
            CreateMap<Sucursal, ViewSucursalDTO>().ReverseMap();

            CreateMap<CondicionTributaria, CondicionTributariaDTO>()
                .ForMember(dest => dest.IdCondicionTributaria, opt => opt.MapFrom(src => (int)src.IdCondicionTributaria))
                .ReverseMap();

            CreateMap<CondicionTributaria, ViewCondicionTributariaDTO>()
                .ForMember(dest => dest.IdCondicionTributaria, opt => opt.MapFrom(src => (int)src.IdCondicionTributaria))
                .ReverseMap();

            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<Empleado, CreateEmpleadoDTO>().ReverseMap();
            CreateMap<Empleado, ViewEmpleadoDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, CreateUsuarioDTO>().ReverseMap();
            CreateMap<Usuario, ViewUsuarioDTO>().ReverseMap();

            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<Rol, CreateRolDTO>().ReverseMap();
            CreateMap<Rol, ViewRolDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, CreateClienteDTO>().ReverseMap();
            CreateMap<Cliente, ViewClienteDTO>().ReverseMap();

            CreateMap<PuntoDeVenta, PuntoDeVentaDTO>().ReverseMap();
            CreateMap<PuntoDeVenta, CreatePuntoDeVentaDTO>().ReverseMap();
            CreateMap<PuntoDeVenta, ViewPuntoDeVentaDTO>().ReverseMap();

            CreateMap<Sesion, SesionDTO>().ReverseMap();
            CreateMap<Sesion, CreateSesionDTO>().ReverseMap();
            CreateMap<Sesion, ViewSesionDTO>().ReverseMap();

            //*---------------------Venta------------------------*
            CreateMap<Venta, VentaDTO>()
                .ForMember(vdto => vdto.Monto, opt => opt.MapFrom(v => v.Monto))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
                .ReverseMap();
            CreateMap<Venta, ViewVentaDTO>()
                .ForMember(vdto => vdto.Monto, opt => opt.MapFrom(v => v.Monto))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
                .ReverseMap(); ;

            CreateMap<LineaDeVenta, LineaDeVentaDTO>().ReverseMap();
            CreateMap<LineaDeVenta, CreateLineaDeVentaDTO>().ReverseMap();
            CreateMap<LineaDeVenta, ViewLineaDeVentaDTO>().ReverseMap();

            CreateMap<Pago, PagoDTO>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
                .ReverseMap();
            CreateMap<Pago, ViewPagoDTO>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
                .ReverseMap();

            CreateMap<TipoDeComprobante, TipoDeComprobanteDTO>().ReverseMap();
            CreateMap<TipoDeComprobante, CreateTipoDeComprobanteDTO>().ReverseMap();
            CreateMap<TipoDeComprobante, ViewTipoDeComprobanteDTO>().ReverseMap();

            CreateMap<Comprobante, ComprobanteDTO>().ReverseMap();
            CreateMap<Comprobante, ViewComprobanteDTO>().ReverseMap();
        }
    }
}
