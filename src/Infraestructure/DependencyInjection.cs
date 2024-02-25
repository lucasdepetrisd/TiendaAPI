using Application.Data;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Infraestructure.Data;
using Infraestructure.Profiles;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? configuration.GetConnectionString("tiendaDb");

        Console.WriteLine(connectionString);

        services.AddDbContext<TiendaContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ITiendaContext, TiendaContext>();
        services.AddScoped<IRepository<Articulo>, ArticuloRepository>();
        services.AddScoped<IRepository<Categoria>, CategoriaRepository>();
        services.AddScoped<IRepository<Cliente>, ClienteRepository>();
        services.AddScoped<IRepository<Color>, ColorRepository>();
        services.AddScoped<IRepository<Comprobante>, ComprobanteRepository>();
        services.AddScoped<IRepository<CondicionTributaria>, CondicionTributariaRepository>();
        services.AddScoped<IRepository<Empleado>, EmpleadoRepository>();
        services.AddScoped<IRepository<Inventario>, InventarioRepository>();
        services.AddScoped<IRepository<LineaDeVenta>, LineaDeVentaRepository>();
        services.AddScoped<IRepository<Marca>, MarcaRepository>();
        services.AddScoped<IRepository<Pago>, PagoRepository>();
        services.AddScoped<IRepository<PuntoDeVenta>, PuntoDeVentaRepository>();
        services.AddScoped<IRepository<Rol>, RolRepository>();
        services.AddScoped<IRepository<Sesion>, SesionRepository>();
        services.AddScoped<IRepository<Sucursal>, SucursalRepository>();
        services.AddScoped<IRepository<Talle>, TalleRepository>();
        services.AddScoped<IRepository<Tienda>, TiendaRepository>();
        services.AddScoped<IRepository<TipoDeComprobante>, TipoDeComprobanteRepository>();
        services.AddScoped<IRepository<TipoTalle>, TipoTalleRepository>();
        services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
        services.AddScoped<IRepository<Venta>, VentaRepository>();

        var mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutomapperProfile());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
