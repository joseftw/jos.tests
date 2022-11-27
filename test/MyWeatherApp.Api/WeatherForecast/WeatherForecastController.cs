using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWeatherApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWeatherApp.Api.WeatherForecast;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherForecastDbContext _weatherForecastDbContext;

    public WeatherForecastController(WeatherForecastDbContext weatherForecastDbContext)
    {
        _weatherForecastDbContext =
            weatherForecastDbContext ?? throw new ArgumentNullException(nameof(weatherForecastDbContext));
    }

    [HttpGet]
    public IAsyncEnumerable<WeatherForecastListResponse> List()
    {
        return _weatherForecastDbContext.WeatherForecasts
                                        .Take(5)
                                        .OrderBy(x => x.Date)
                                        .Select(x =>
                                            new WeatherForecastListResponse(
                                                x.Date, x.TemperatureCelsius, x.Summary))
                                        .AsAsyncEnumerable();
    }
}
