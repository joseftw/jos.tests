using Microsoft.EntityFrameworkCore;

namespace MyWeatherApp.Database;

public class PostgresDatabaseOptions
{
    public required string ConnectionString { get; init; }

    public DbContextOptions DbContextOptions
    {
        get
        {
            return new DbContextOptionsBuilder()
                .UseNpgsql(ConnectionString,
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly("MyWeatherApp.Database"))
                .UseSnakeCaseNamingConvention().Options;
        }
    }
}
