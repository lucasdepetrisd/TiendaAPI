using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Infraestructure;
using Microsoft.Extensions.Configuration;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);

        services.AddInfraestructure(configuration);

        return services;
    }
}
