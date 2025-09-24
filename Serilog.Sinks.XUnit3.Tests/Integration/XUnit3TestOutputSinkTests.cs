using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Serilog.Sinks.XUnit3.Tests.Integration;

[Collection(nameof(SampleCollection))]
public class XUnit3TestOutputSinkTests(SampleFixture fixture, ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Log_Always_Success()
    {
        var mockTestOutputHelper = Substitute.For<ITestOutputHelper>();
        var testFixture = fixture.SetTestOutputHelper(
            new TestOutputHelperDecorator(testOutputHelper, mockTestOutputHelper));
        var logger = testFixture.Factory.Services.GetRequiredService<ILogger<object>>();
        for (var i = 0; i < 10; i++)
            logger.LogInformation("Log_Always_Success");
        mockTestOutputHelper.Received(10)
            .WriteLine(Arg.Is<string>(s => s.Contains("Log_Always_Success")));
    }
}