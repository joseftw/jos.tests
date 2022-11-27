using JOS.Tests.Integration;
using Microsoft.EntityFrameworkCore;
using MyWeatherApp.Database;
using Npgsql;
using Respawn;
using Respawn.Graph;
using System.Threading.Tasks;

namespace MyWeatherApp.Api.Tests;

public class PostgresDatabaseFixture : DatabaseFixture
{
    private readonly PostgresDatabaseOptions _postgresDatabaseOptions;

    public PostgresDatabaseFixture()
    {
        var configuration = new MyWeatherAppApiTestConfiguration();
        _postgresDatabaseOptions = new PostgresDatabaseOptions
        {
            ConnectionString = configuration.PostgresConnectionString
        };
    }

    public override async Task InitializeAsync()
    {
        await using var dbContext = new WeatherForecastDbContext(_postgresDatabaseOptions);
        await dbContext.Database.MigrateAsync();
    }

    public override Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task ResetDatabase()
    {
        await using var npsqlConnection = new NpgsqlConnection(_postgresDatabaseOptions.ConnectionString);
        await npsqlConnection.OpenAsync();
        var respawner = await Respawner.CreateAsync(npsqlConnection,
            new RespawnerOptions
            {
                DbAdapter = DbAdapter.Postgres,
                SchemasToInclude = new[] { "public" },
                TablesToIgnore = new Table[] { "__EFMigrationsHistory" }
            });
        await respawner.ResetAsync(npsqlConnection);
    }

    public WeatherForecastDbContext CreateWeatherForecastDbContext()
    {
        return new WeatherForecastDbContext(_postgresDatabaseOptions);
    }
}
