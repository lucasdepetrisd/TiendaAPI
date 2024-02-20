using AutoMapper;
using Domain.Models;
using Domain.DTOs;

namespace Infraestructure.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Articulo, ArticuloDTO>().ReverseMap();
            CreateMap<Articulo, CreateArticuloDTO>().ReverseMap();

            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Marca, ShowMarcaDTO>().ReverseMap();

            CreateMap<TipoTalle, TipoTalleDTO>().ReverseMap();
            CreateMap<TipoTalle, ShowTipoTalleDTO>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, ShowCategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CreateCategoriaDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<Comprobante, ComprobanteDTO>().ReverseMap();
            CreateMap<CondicionTributaria, CondicionTributariaDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<Inventario, InventarioDTO>().ReverseMap();
            CreateMap<LineaDeVenta, LineaDeVentaDTO>().ReverseMap();

            CreateMap<Pago, PagoDTO>().ReverseMap();
            CreateMap<PuntoDeVenta, PuntoDeVentaDTO>().ReverseMap();
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<Sesion, SesionDTO>().ReverseMap();
            CreateMap<Sucursal, SucursalDTO>().ReverseMap();
            CreateMap<Talle, TalleDTO>().ReverseMap();
            CreateMap<Tienda, TiendaDTO>().ReverseMap();
            CreateMap<TipoDeComprobante, TipoDeComprobanteDTO>().ReverseMap();


            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Venta, VentaDTO>().ReverseMap();
        }
    }
}
