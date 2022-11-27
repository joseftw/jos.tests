using Microsoft.Extensions.DependencyInjection;
using MyWeatherApp.Common;

namespace MyWeatherApp.Database;

public static class DatabaseExtensions
{
    public static void AddDatabase(this IServiceCollection services)
    {
        services.AddValidatedOptions<PostgresDatabaseOptions>("Postgres");
        services.AddDbContext<WeatherForecastDbContext>();
    }
}
