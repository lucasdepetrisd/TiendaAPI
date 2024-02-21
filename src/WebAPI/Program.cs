using Application;
using Infraestructure;
using Microsoft.AspNetCore.Hosting;
using SwaggerThemes;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Configuration;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Layers DI
builder.Services
    .AddApplication()
    .AddInfraestructure(builder.Configuration);

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

// Configure the HTTP request pipeline.
app.UseStaticFiles();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    //app.UseSwaggerThemes(Theme.OneDark);
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(DocExpansion.None);
        options.InjectStylesheet("/Swagger/SwaggerDark.css");
        options.EnableTryItOutByDefault();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT");
    app.Urls.Add($"http://*:{port}");
}
/*var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var host = Environment.GetEnvironmentVariable("applicationUrl") ?? "localhost";*/
app.Run();
