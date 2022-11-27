using Microsoft.EntityFrameworkCore;
using MyWeatherApp.Core;

namespace MyWeatherApp.Database;

public class WeatherForecastDbContext : DbContext
{
    public WeatherForecastDbContext(PostgresDatabaseOptions postgresDatabaseOptions)
        : base(postgresDatabaseOptions.DbContextOptions)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<WeatherForecast>(x => x.HasKey(wf => wf.Id));
        builder.Entity<WeatherForecast>().Property(x => x.TemperatureCelsius).IsRequired();
        builder.Entity<WeatherForecast>()
               .Property(x => x.Summary)
               .HasMaxLength(WeatherForecast.SummaryMaxLength)
               .IsRequired();
        builder.Entity<WeatherForecast>().Property(x => x.Date).IsRequired();
    }
}
