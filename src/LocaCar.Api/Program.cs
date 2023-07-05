using LocaCar.Api.Chatbot;
using LocaCar.Api.Data;
using LocaCar.Api.Imports;
using LocaCar.Api.Interfaces.Repositories;
using LocaCar.Api.Interfaces.Services;
using LocaCar.Api.Repositories;
using LocaCar.Api.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var configuration = builder.Configuration.AddEnvironmentVariables().Build();
var connectionString = $"server={configuration["MYSQL_HOST"]};port={configuration["MYSQL_PORT"]};database={configuration["MYSQL_DATABASE"]};user={configuration["MYSQL_USER"]};password={configuration["MYSQL_PASSWORD"]}";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LocaCar", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "A API Key para acessar a API",
        Type = SecuritySchemeType.ApiKey,
        Name = "LocaCar-Api-Key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { scheme, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});

builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<ChatbotClient>();

builder.Services.AddScoped<MarcaDataImporter>();
builder.Services.AddScoped<ModeloAnoDataImporter>();
builder.Services.AddHostedService<ImportsBackgroundService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/", () => "API is running");

app.MapControllers();

app.UseMetricServer();

app.UseHttpMetrics();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var databaseInitializer = new DbInitializer(dbContext);
    databaseInitializer.Initialize();
}

app.Run();
