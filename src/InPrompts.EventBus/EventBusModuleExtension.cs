using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Serilog;
using InPrompts.Prompts.Data;

namespace InPrompts.EventBus;

public static class EventBusModuleExtension
{
  public static IServiceCollection AddEventBusModule(this IServiceCollection services, IConfiguration configuration, ILogger logger, List<Assembly> assemblies)
  {
    var connectionString = configuration.GetConnectionString("EventBus");
    services.AddDbContext<SagaDbContext>(config => config.UseNpgsql(connectionString));

    services.AddMassTransit(busConfigurator =>
    {
      busConfigurator.SetKebabCaseEndpointNameFormatter();

      busConfigurator.AddConsumers(typeof(EventBusModuleExtension).Assembly);

      busConfigurator.AddSagaStateMachine<EmailNewUserSaga, EmailNewUserSagaData>()
      .EntityFrameworkRepository(r =>
      {
        r.ExistingDbContext<SagaDbContext>();

        r.UsePostgres();
      });

      busConfigurator.UsingRabbitMq((context, cfg) =>
      {
        cfg.Host("localhost", "/", hst =>
      {
        hst.Username(configuration["MessageBroker:Username"]!);
        hst.Password(configuration["MessageBroker:Password"]!);
      });

        cfg.UseInMemoryOutbox(context);

        cfg.ConfigureEndpoints(context);
      });
    });

    assemblies.Add(typeof(EventBusModuleExtension).Assembly);
    // services.AddScoped<IEmailService, EmailService>();
    services.AddScoped<IMessagePublisher, MessagePublisher>();
    logger.Information("{Module} module services registered", "EventBus");

    return services;
  }
}