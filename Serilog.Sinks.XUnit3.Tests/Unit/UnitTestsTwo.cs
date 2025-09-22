using Microsoft.Extensions.Logging;
using Microsoft.Testing.Platform.Services;

namespace Serilog.Sinks.XUnit3.Tests.Unit;

[Collection(nameof(ServiceProviderCollection))]
public class UnitTestsTwo(ServiceProviderFixture fixture)
{
    [Fact]
    public void Loop_Always_Success()
    {
        var logger = fixture.ServiceProvider.GetRequiredService<ILogger<object>>();
        for (var i = 0; i < 10; i++)
            logger.LogInformation("Do");
    }
}