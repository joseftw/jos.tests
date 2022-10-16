using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWeatherApp.Core;

namespace MyWeatherApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> List()
    {
        return new List<WeatherForecast>
        {
            new() { Date = DateOnly.Parse("2022-10-17"), Summary = "Freezing", TemperatureCelsius = 12 },
            new() { Date = DateOnly.Parse("2022-10-18"), Summary = "Bracing", TemperatureCelsius = 13 },
            new() { Date = DateOnly.Parse("2022-10-19"), Summary = "Chilly", TemperatureCelsius = 14 },
            new() { Date = DateOnly.Parse("2022-10-20"), Summary = "Cool", TemperatureCelsius = 14 },
            new() { Date = DateOnly.Parse("2022-10-21"), Summary = "Mild", TemperatureCelsius = 14 }
        };
    }
}
