using JOS.Tests;

namespace MyWeatherApp.Api.Tests;

public class MyWeatherAppApiTestConfiguration : TestConfiguration
{
    public MyWeatherAppApiTestConfiguration()
    {
        this["ASPNETCORE_ENVIRONMENT"] = "TestRunner";
    }
}