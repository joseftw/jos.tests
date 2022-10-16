using System;

namespace MyWeatherApp.Core;

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}
