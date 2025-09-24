using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Serilog.Sinks.XUnit3.Tests.Integration;

public class SampleFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddSingleton(Options.Create(new XUnit3TestOutputSinkOptions()));
            services.AddSingleton<XUnit3TestOutputSink>();
        });
        builder.UseSerilog((_, serviceProvider, loggerConfiguration) =>
            loggerConfiguration.WriteTo.XUnit3TestOutput(
                serviceProvider.GetRequiredService<XUnit3TestOutputSink>()));

        return base.CreateHost(builder);
    }

    public void SetTestOutputHelper(ITestOutputHelper testOutputHelper) =>
        Services.GetRequiredService<XUnit3TestOutputSink>().TestOutputHelper = testOutputHelper;
}
