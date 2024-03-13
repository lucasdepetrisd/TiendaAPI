using Domain.Data;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.ViewRepositories;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Infraestructure.Repositories.CrudRepositories;
using Infraestructure.Repositories.ViewRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        if (Environment.GetEnvironmentVariable("localDb") != null)
        {
            services.AddDbContext<TiendaContext>();
            services.AddScoped<ITiendaContext, TiendaContext>();
        }
        else if (Environment.GetEnvironmentVariable("AzureSQL") != null)
        {
            services.AddDbContext<AzureTiendaContext>();
            services.AddScoped<ITiendaContext, AzureTiendaContext>();
        }

        services.AddScoped<IArticuloRepository, ArticuloRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ITiendaRepository, TiendaRepository>();

        services.AddScoped<IViewRepository<CondicionTributaria>, CondicionTributariaRepository>();
        services.AddScoped<IViewRepository<Sucursal>, SucursalRepository>();

        services.AddScoped<ICrudRepository<TipoDeComprobante>, TipoDeComprobanteRepository>();
        services.AddScoped<ICrudRepository<LineaDeVenta>, LineaDeVentaRepository>();
        services.AddScoped<ICrudRepository<Comprobante>, ComprobanteRepository>();
        services.AddScoped<ICrudRepository<Categoria>, CategoriaRepository>();
        services.AddScoped<ICrudRepository<Cliente>, ClienteRepository>();
        services.AddScoped<ICrudRepository<Color>, ColorRepository>();
        services.AddScoped<ICrudRepository<Empleado>, EmpleadoRepository>();
        services.AddScoped<ICrudRepository<Inventario>, InventarioRepository>();
        services.AddScoped<ICrudRepository<Marca>, MarcaRepository>();
        services.AddScoped<ICrudRepository<Pago>, PagoRepository>();
        services.AddScoped<ICrudRepository<PuntoDeVenta>, PuntoDeVentaRepository>();
        services.AddScoped<ICrudRepository<Rol>, RolRepository>();
        services.AddScoped<ICrudRepository<Sesion>, SesionRepository>();
        services.AddScoped<ICrudRepository<Talle>, TalleRepository>();
        services.AddScoped<ICrudRepository<TipoTalle>, TipoTalleRepository>();
        services.AddScoped<ICrudRepository<Venta>, VentaRepository>();

        return services;
    }
}
