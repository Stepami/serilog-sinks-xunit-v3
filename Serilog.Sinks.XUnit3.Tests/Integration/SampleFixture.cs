namespace Serilog.Sinks.XUnit3.Tests.Integration;

public class SampleFixture : IAsyncLifetime
{
    public SampleFactory Factory { get; private set; } = null!;

    public SampleFixture SetTestOutputHelper(ITestOutputHelper testOutputHelper)
    {
        Factory.SetTestOutputHelper(testOutputHelper);
        return this;
    }

    public ValueTask InitializeAsync()
    {
        Factory = new SampleFactory();
        return ValueTask.CompletedTask;
    }

    public async ValueTask DisposeAsync() => await Factory.DisposeAsync();
}
