using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Serilog.Sinks.XUnit3.Tests.Unit;

public class ServiceProviderFixture : IAsyncLifetime
{
    public ServiceProvider ServiceProvider { get; private set; } = null!;

    private readonly ServiceCollection _services = new();

    public ServiceProviderFixture()
    {
        _services.AddLogging(x => x.ClearProviders().AddSerilog(
            new LoggerConfiguration().WriteTo.XUnit3TestOutput().CreateLogger()));
    }

    public ValueTask InitializeAsync()
    {
        ServiceProvider = _services.BuildServiceProvider();
        return ValueTask.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        ServiceProvider.Dispose();
        return ValueTask.CompletedTask;
    }
}