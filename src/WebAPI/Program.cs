using Application;
using Infraestructure;
using Microsoft.AspNetCore.Hosting;
using SwaggerThemes;
using Swashbuckle.AspNetCore.SwaggerUI;

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

// Configure the HTTP request pipeline.
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
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
else if (app.Environment.IsEnvironment("Production"))
{
    var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
    var userPassSide = connectionUrl.Split("@")[0];
    var hostSide = connectionUrl.Split("@")[1];

    var user = userPassSide.Split(":")[0];
    var password = userPassSide.Split(":")[1];
    var host = hostSide.Split("/")[0];
    var database = hostSide.Split("/")[1].Split("?")[0];

    defaultConnectionString = $"Host={host};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
