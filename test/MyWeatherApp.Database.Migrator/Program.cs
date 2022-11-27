using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyWeatherApp.Database;

using var host = CreateHostBuilder(args).Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
var environment = host.Services.GetRequiredService<IHostEnvironment>();
logger.LogInformation("Application environment: {EnvironmentName}", environment.EnvironmentName);
var scope = host.Services.CreateAsyncScope();

await using(scope)
{
    await using var weatherForecastDbContext = scope.ServiceProvider.GetRequiredService<WeatherForecastDbContext>();
    logger.LogInformation("Migrating {DbContextName}...", nameof(WeatherForecastDbContext));
    await weatherForecastDbContext.Database.MigrateAsync();
    logger.LogInformation("Migration of {DbContextName} done", nameof(WeatherForecastDbContext));
}

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((context, builder) =>
               {
                   builder.AddJsonFile("appsettings.json");
                   builder.AddJsonFile(
                       $"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                   builder.AddEnvironmentVariables("MyWeatherApp_Database_Migrator_");
                   builder.AddCommandLine(args);
               })
               .ConfigureLogging((_, builder) =>
               {
                   builder.AddJsonConsole(options =>
                   {
                       options.IncludeScopes = true;
                       options.UseUtcTimestamp = true;
                   });
               })
               .ConfigureServices((_, services) =>
               {
                   services.AddDatabase();
               });
}
