using Application.Data;
using AutoMapper;
using Infraestructure.Data;
using Infraestructure.Profiles;
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
        //services.AddDbContext<TiendaContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));
        services.AddDbContext<TiendaContext>(options => options.UseSqlServer(configuration.GetConnectionString("localSQL")));

        services.AddScoped<ITiendaContext, TiendaContext>();
        //services.AddScoped<ITiendaContext>(sp => sp.GetRequiredService<TiendaContext>());

        var mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutomapperProfile());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
