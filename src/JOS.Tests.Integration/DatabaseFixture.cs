using System.Threading.Tasks;
using Xunit;

namespace JOS.Tests.Integration;

public abstract class DatabaseFixture : IAsyncLifetime
{
    public abstract Task InitializeAsync();

    public abstract Task DisposeAsync();
}
