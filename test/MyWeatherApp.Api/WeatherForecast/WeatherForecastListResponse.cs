using System;

namespace MyWeatherApp.Api.WeatherForecast;

public record WeatherForecastListResponse(DateOnly Date, int Temperature, string Summary);
