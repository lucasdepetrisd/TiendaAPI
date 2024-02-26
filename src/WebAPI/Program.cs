using Application;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

/*
var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("https://webapi-vault.vault.azure.net/"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());*/

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("Crud", new OpenApiInfo { Title = "La Tienda API: CRUD", Version = "v1.2" });
    c.SwaggerDoc("UseCases", new OpenApiInfo { Title = "La Tienda API: Casos de Uso", Version = "v1.2" });

    string[] methodsOrder = ["get", "post", "put", "patch", "delete", "options", "trace"];
    c.OrderActionsBy((apiDesc) =>
    {
        var method = apiDesc.HttpMethod?.ToLower();
        var order = Array.IndexOf(methodsOrder, method);
        return $"{order}_{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.RelativePath}";
    });
});

builder.Configuration.AddEnvironmentVariables();

// Layers DI
builder.Services
    .AddApplication(builder.Configuration);

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    if (context.Request.Path == "/crud" || context.Request.Path == "/swagger/crud")
    {
        context.Response.Redirect("/swagger/index.html?urls.primaryName=CRUD%20Docs");
        return;
    }

    if (context.Request.Path == "/usecases" || context.Request.Path == "/swagger/usecases")
    {
        context.Response.Redirect("/swagger/index.html?urls.primaryName=Use%20Cases%20Docs");
        return;
    }

    await next();
});

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/Crud/swagger.json", "CRUD Docs");
    options.SwaggerEndpoint("/swagger/UseCases/swagger.json", "Use Cases Docs");

    options.DocExpansion(DocExpansion.None);
    options.InjectStylesheet("/Swagger/SwaggerDark.css");
    options.EnableTryItOutByDefault();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

/*var context = app.Services.GetService<ITiendaContext>();

// Fetch the data needed for creating a Venta
// Example: Fetch cliente, usuario, tipoDeComprobante, puntoDeVenta, etc.
var cliente = context.Cliente.FirstOrDefault(c => c.IdCliente == 4);
var usuario = context.Usuario.FirstOrDefault(u => u.IdUsuario == 1);
var tipoDeComprobante = context.TipoDeComprobante.FirstOrDefault(tc => tc.IdTipoDeComprobante == 1);
var puntoDeVenta = context.PuntoDeVenta.FirstOrDefault(pv => pv.IdPuntoDeVenta == 1);
var inventario = context.Inventario.Include(i => i.Articulo).FirstOrDefault(i => i.IdInventario == 1);

// Create a new Venta instance using the fetched data
var venta = new Venta(usuario, puntoDeVenta);

context.Venta.Add(venta);
await context.SaveChangesAsync();

venta.NuevaLineaDeVenta(4, 21, inventario);

context.Venta.Entry(venta).State = EntityState.Modified;
await context.SaveChangesAsync();

// Example: Print the venta details
Console.WriteLine($"Nueva Venta creada: IdVenta={venta.IdVenta}, Fecha={venta.Fecha}, Monto={venta.Monto}, Estado={venta.Estado}, Cliente={venta.Cliente.Nombre}");*/