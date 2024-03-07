using Application.Contracts;
using Application.Services;
using AutoMapper;
using Domain.Profiles;
using FluentValidation;
using Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddValidatorsFromAssembly(assembly);

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<IArticuloService, ArticuloService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<IComprobanteService, ComprobanteService>();
        services.AddScoped<ICondicionTributariaService, CondicionTributariaService>();
        services.AddScoped<IEmpleadoService, EmpleadoService>();
        services.AddScoped<IInventarioService, InventarioService>();
        services.AddScoped<ILineaDeVentaService, LineaDeVentaService>();
        services.AddScoped<IMarcaService, MarcaService>();
        services.AddScoped<IPagoService, PagoService>();
        services.AddScoped<IPuntoDeVentaService, PuntoDeVentaService>();
        services.AddScoped<IRolService, RolService>();
        services.AddScoped<ISesionService, SesionService>();
        services.AddScoped<ISucursalService, SucursalService>();
        services.AddScoped<ITalleService, TalleService>();
        services.AddScoped<ITiendaService, TiendaService>();
        services.AddScoped<ITipoDeComprobanteService, TipoDeComprobanteService>();
        services.AddScoped<ITipoTalleService, TipoTalleService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IVentaService, VentaService>();

        services.AddInfraestructure(configuration);

        var mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutomapperProfile());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
