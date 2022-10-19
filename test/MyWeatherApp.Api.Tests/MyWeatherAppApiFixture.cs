using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace MyWeatherApp.Api.Tests;

public class MyWeatherAppApiFixture : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var testConfiguration = new MyWeatherAppApiTestConfiguration();
        builder
            .UseEnvironment(testConfiguration["ASPNETCORE_ENVIRONMENT"])
            .ConfigureAppConfiguration(configurationBuilder =>
            {
                configurationBuilder.AddInMemoryCollection(testConfiguration!);
            });
    }
}
