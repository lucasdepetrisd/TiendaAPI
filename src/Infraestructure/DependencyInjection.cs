using Application.Data;
using Infraestructure.Data;
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

        return services;
    }
}
