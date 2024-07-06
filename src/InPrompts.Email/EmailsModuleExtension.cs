using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

using Serilog;

namespace InPrompts.Email;

public static class EmailsModuleExtension
{
  public static IServiceCollection AddEmailModule(this IServiceCollection services, IConfiguration config, ILogger logger, List<Assembly> assemblies)
  {
    services.AddTransient<IMimeKitEmailSender, MimeKitEmailSender>();
    services.AddTransient<IGetOutboxService, GetOutBoxService>();
    services.AddTransient<IQueueSendService, QueueSendService>();
    services.AddTransient<ISendOutboxService, SendEmailService>();

    services.Configure<MongoDbSettings>(config.GetSection("MongoDB"));
    services.AddMongoDb(config);
    assemblies.Add(typeof(EmailsModuleExtension).Assembly);

    services.AddHostedService<EmailBackgroundService>();

    logger.Information("{Module} module services registered", "Email");

    return services;
  }

  private static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration config)
  {
    var settings = config.GetSection("MongoDB").Get<MongoDbSettings>() ?? throw new Exception("Missing MongoDB settings");

    services.AddSingleton<IMongoClient>(_ => new MongoClient(settings.ConnectionString));

    services.AddSingleton(serviceProvider =>
    {
      var client = serviceProvider.GetRequiredService<IMongoClient>();
      return client.GetDatabase(settings.DatabaseName);
    });

    services.AddTransient(serviceProvider =>
    {
      var database = serviceProvider.GetRequiredService<IMongoDatabase>();
      return database.GetCollection<EmailOutboxEntity>("EmailOutBoxEntityCollection");
    });
    return services;
  }
}
