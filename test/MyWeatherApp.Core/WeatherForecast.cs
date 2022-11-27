using System;

namespace MyWeatherApp.Core;

public class WeatherForecast
{
    public const int SummaryMaxLength = 256;
    private WeatherForecast(Guid id, DateOnly date, int temperatureCelsius, string summary)
    {
        Id = id;
        Date = date;
        TemperatureCelsius = temperatureCelsius;
        Summary = summary;
    }
    public Guid Id { get; }
    public DateOnly Date { get; }
    public int TemperatureCelsius { get; }
    public string Summary { get; }

    public static WeatherForecast Create(Guid id, DateOnly date, int temperatureCelsius, string summary)
    {
        // TODO Add validation
        return new WeatherForecast(id, date, temperatureCelsius, summary);
    }
}
