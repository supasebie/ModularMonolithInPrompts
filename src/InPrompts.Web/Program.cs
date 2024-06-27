using InPrompts.SharedKernel;

using System.Reflection;

using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

using InPrompts.Prompts;
using InPrompts.Users;

using Serilog;
using InPrompts.Users.UseCases;
using AutoMapper;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, config) =>
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints()
    .AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["Auth:JwtSecret"]!)
    .AddAuthorization()
    .SwaggerDocument();

// Initialize assemblies and add module assemblies
List<Assembly> appAssemblies = [typeof(InPrompts.Web.Program).Assembly];
builder.Services
    .AddPromptModule(builder.Configuration, logger, appAssemblies)
    .AddUserModule(builder.Configuration, logger, appAssemblies);

// Configure AutoMapper
builder.Services.AddAutoMapper(config => config.AddMaps(appAssemblies.ToArray()));

// Configure MediatR
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(appAssemblies.ToArray()));
builder.Services.AddMediatRLoggingBehavior();
builder.Services.AddMediatRFluentValidationValidationBehavior();
builder.Services.AddValidatorsFromAssemblyContaining<AddUserPromptCommandValidator>();

// Event Dispatcher Configuration
builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

namespace InPrompts.Web
{
    public partial class Program { };
}
