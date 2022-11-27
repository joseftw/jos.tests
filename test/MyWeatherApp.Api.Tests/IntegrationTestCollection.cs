using Xunit;

namespace MyWeatherApp.Api.Tests;

[CollectionDefinition(Name)]
public class IntegrationTestCollection : ICollectionFixture<PostgresDatabaseFixture>
{
    public const string Name = "Integration Test";
}
