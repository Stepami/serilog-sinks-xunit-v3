using Microsoft.Extensions.Logging;
using Microsoft.Testing.Platform.Services;

namespace Serilog.Sinks.XUnit3.Tests.Unit;

[Collection(nameof(ServiceProviderCollection))]
public class UnitTestsOne(ServiceProviderFixture fixture)
{
    [Fact]
    public void Do_Always_Success()
    {
        var logger = fixture.ServiceProvider.GetRequiredService<ILogger<object>>();
        logger.LogInformation("Do");
    }
}