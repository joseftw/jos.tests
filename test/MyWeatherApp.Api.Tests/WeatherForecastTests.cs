using JOS.Tests.Integration;
using Shouldly;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace MyWeatherApp.Api.Tests;

[Collection(IntegrationTestCollection.Name)]
public class WeatherForecastTests : IClassFixture<MyWeatherAppApiFixture>
{
    private readonly MyWeatherAppApiFixture _fixture;

    public WeatherForecastTests(MyWeatherAppApiFixture fixture)
    {
        _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }
    
    [Fact]
    public async Task GET_WeatherForecast_ShouldReturn200Ok()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/weatherforecast");
        var client = _fixture.CreateClient();

        using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GET_WeatherForecast_ShouldReturnExpectedForecast()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/weatherforecast");
        var client = _fixture.CreateClient();

        using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStreamAsync();
        var jsonResponse = await JsonDocument.ParseAsync(responseContent);
        var weatherForecastResponse = jsonResponse.RootElement.EnumerateArray();
        weatherForecastResponse.Count().ShouldBe(5);
        AssertWeatherForecast(weatherForecastResponse.ElementAt(0), "2022-10-17", "Freezing", 12);
        AssertWeatherForecast(weatherForecastResponse.ElementAt(1), "2022-10-18", "Bracing", 13);
        AssertWeatherForecast(weatherForecastResponse.ElementAt(2), "2022-10-19", "Chilly", 14);
        AssertWeatherForecast(weatherForecastResponse.ElementAt(3), "2022-10-20", "Cool", 14);
        AssertWeatherForecast(weatherForecastResponse.ElementAt(4), "2022-10-21", "Mild", 14);
    }

    private static void AssertWeatherForecast(
        JsonElement weatherForecast, string date, string summary, int temperatureC)
    {
        weatherForecast.GetProperty("date").GetString().ShouldBe(date);
        weatherForecast.GetProperty("summary").GetString().ShouldBe(summary);
        weatherForecast.GetProperty("temperatureCelsius").GetInt32().ShouldBe(temperatureC);
    }
}
