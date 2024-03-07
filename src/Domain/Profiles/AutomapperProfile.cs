using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Domain.Profiles
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
            CreateMap<Sucursal, CreateSucursalDTO>().ReverseMap();
            CreateMap<Sucursal, ViewSucursalDTO>().ReverseMap();

            CreateMap<CondicionTributaria, CondicionTributariaDTO>()
                .ForMember(dest => dest.IdCondicionTributaria, opt => opt.MapFrom(src => (int)src.IdCondicionTributaria))
                .ReverseMap();

            CreateMap<CondicionTributaria, ViewCondicionTributariaDTO>().ReverseMap();

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
            CreateMap<Venta, VentaDTO>().ReverseMap();
            CreateMap<Venta, CreateVentaDTO>().ReverseMap();
            CreateMap<Venta, ViewVentaDTO>().ReverseMap();

            CreateMap<LineaDeVenta, LineaDeVentaDTO>().ReverseMap();
            CreateMap<LineaDeVenta, CreateLineaDeVentaDTO>().ReverseMap();
            CreateMap<LineaDeVenta, ViewLineaDeVentaDTO>().ReverseMap();

            CreateMap<Pago, PagoDTO>().ReverseMap();
            CreateMap<Pago, CreatePagoDTO>().ReverseMap();
            CreateMap<Pago, ViewPagoDTO>().ReverseMap();

            CreateMap<TipoDeComprobante, TipoDeComprobanteDTO>().ReverseMap();
            CreateMap<TipoDeComprobante, CreateTipoDeComprobanteDTO>().ReverseMap();
            CreateMap<TipoDeComprobante, ViewTipoDeComprobanteDTO>().ReverseMap();

            CreateMap<Comprobante, ComprobanteDTO>().ReverseMap();
            CreateMap<Comprobante, CreateComprobanteDTO>().ReverseMap();
        }
    }
}
