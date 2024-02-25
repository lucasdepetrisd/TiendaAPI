﻿using Application.Data;
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
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? configuration.GetConnectionString("localSQL");

        Console.WriteLine(connectionString);

        services.AddDbContext<TiendaContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ITiendaContext, TiendaContext>();

        var mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutomapperProfile());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
