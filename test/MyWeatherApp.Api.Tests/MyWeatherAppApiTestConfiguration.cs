using JOS.Tests;

namespace MyWeatherApp.Api.Tests;

public class MyWeatherAppApiTestConfiguration : TestConfiguration
{
    public MyWeatherAppApiTestConfiguration()
    {
        this["ASPNETCORE_ENVIRONMENT"] = "TestRunner";
        this["Postgres:ConnectionString"] =
            "Host=127.0.0.1;Port=5432;Username=my_weather_app;Password=my_password;Database=my_weather_app_test";
    }

    public string PostgresConnectionString => this["Postgres:ConnectionString"];
}
