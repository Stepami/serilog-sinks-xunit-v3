using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Serilog.Sinks.XUnit3.Tests.Integration;

public class SampleFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var sink = new XUnit3TestOutputSink();

        builder.ConfigureServices(services => services.AddSingleton(sink));
        builder.UseSerilog((_, loggerConfiguration) => loggerConfiguration.WriteTo.XUnit3TestOutput(sink));

        return base.CreateHost(builder);
    }

    public void SetTestOutputHelper(ITestOutputHelper testOutputHelper) =>
        Services.GetRequiredService<XUnit3TestOutputSink>().TestOutputHelper = testOutputHelper;
}
