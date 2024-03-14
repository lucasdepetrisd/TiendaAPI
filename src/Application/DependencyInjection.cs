using Application.Contracts.CrudServices;
using Application.Contracts.ExternalServices;
using Application.Contracts.UseCasesServices;
using Application.Contracts.ViewServices;
using Application.Profiles;
using Application.Services;
using Application.Services.CrudServices;
using Application.Services.ExternalServices;
using Application.Services.UseCasesServices;
using Application.Services.ViewServices;
using Application.ServicioExternoAfip;
using AutoMapper;
using FluentValidation;
using Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection Services,
        IConfiguration Configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        Services.AddValidatorsFromAssembly(assembly);

        var DecidirApiSection = Configuration.GetSection("AutorizacionTarjetaApis:DecidirApi");

        Services.Configure<AutorizacionTarjetaApisSettings>(
            AutorizacionTarjetaApisSettings.TokenEndpoint,
            DecidirApiSection.GetSection("tokenEndpoint"));

        Services.Configure<AutorizacionTarjetaApisSettings>(
            AutorizacionTarjetaApisSettings.PaymentEndpoint,
            DecidirApiSection.GetSection("paymentEndpoint"));

        Services.Configure<AutorizacionAfipSettings>(
            Configuration.GetSection(AutorizacionAfipSettings.AutorizacionAfip));

        Services.AddHttpClient<IAutorizacionTarjetaService, AutorizacionTarjetaService>();
        Services.AddScoped<ILoginService, LoginServiceClient>();

        Services.AddScoped<IAutorizacionAfipService, AutorizacionAfipService>();
        Services.AddScoped<IAutorizacionTarjetaService, AutorizacionTarjetaService>();
        Services.AddScoped<IAutenticacionUsuarioService, AutenticacionUsuarioService>();

        Services.AddScoped<IArticuloService, ArticuloService>();
        Services.AddScoped<ICategoriaService, CategoriaService>();
        Services.AddScoped<IClienteService, ClienteService>();
        Services.AddScoped<IColorService, ColorService>();
        Services.AddScoped<IComprobanteService, ComprobanteService>();
        Services.AddScoped<ICondicionTributariaService, CondicionTributariaService>();
        Services.AddScoped<IEmpleadoService, EmpleadoService>();
        Services.AddScoped<IInventarioService, InventarioService>();
        Services.AddScoped<ILineaDeVentaService, LineaDeVentaService>();
        Services.AddScoped<IMarcaService, MarcaService>();
        Services.AddScoped<IPagoService, PagoService>();
        Services.AddScoped<IPuntoDeVentaService, PuntoDeVentaService>();
        Services.AddScoped<IRolService, RolService>();
        Services.AddScoped<ISesionService, SesionService>();
        Services.AddScoped<ISucursalService, SucursalService>();
        Services.AddScoped<ITalleService, TalleService>();
        Services.AddScoped<ITiendaService, TiendaService>();
        Services.AddScoped<ITipoDeComprobanteService, TipoDeComprobanteService>();
        Services.AddScoped<ITipoTalleService, TipoTalleService>();
        Services.AddScoped<IUsuarioService, UsuarioService>();
        Services.AddScoped<IVentaService, VentaService>();

        Services.AddInfraestructure(Configuration);

        var mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutomapperProfile());
        });

        var mapper = mapperConfiguration.CreateMapper();
        Services.AddSingleton(mapper);

        return Services;
    }
}
