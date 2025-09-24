namespace Serilog.Sinks.XUnit3.Tests.Integration;

internal sealed class TestOutputHelperDecorator(
    ITestOutputHelper realTestOutputHelper,
    ITestOutputHelper mockTestOutputHelper) : ITestOutputHelper
{
    public void Write(string message)
    {
        realTestOutputHelper.Write(message);
        mockTestOutputHelper.Write(message);
    }

    public void Write(string format, params object[] args)
    {
        realTestOutputHelper.Write(format, args);
        mockTestOutputHelper.Write(format, args);
    }

    public void WriteLine(string message)
    {
        realTestOutputHelper.WriteLine(message);
        mockTestOutputHelper.WriteLine(message);
    }

    public void WriteLine(string format, params object[] args)
    {
        realTestOutputHelper.WriteLine(format, args);
        mockTestOutputHelper.WriteLine(format, args);
    }

    public string Output => realTestOutputHelper.Output;
}