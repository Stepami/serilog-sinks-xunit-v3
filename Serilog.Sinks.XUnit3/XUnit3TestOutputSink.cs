using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Core;
using Xunit;

namespace Serilog.Sinks.XUnit3;

/// <summary>
///     The sink for logging through Serilog to xUnit.v3 test output.
///     The instance of this class needs to be injected to DI.
/// </summary>
/// <param name="outputTemplate">Format of the log message</param>
/// <param name="formatProvider">Format source</param>
public sealed class XUnit3TestOutputSink(
    string outputTemplate = XUnit3TestOutputSink.DefaultTemplate,
    IFormatProvider? formatProvider = null) : ILogEventSink
{
    private const string DefaultTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{Exception}";

    private readonly MessageTemplateTextFormatter _messageTemplateTextFormatter = new(outputTemplate, formatProvider);

    /// <summary>
    ///     Reference to xUnit.v3 <see cref="ITestOutputHelper"/>.
    ///     Needs to be set through DI in cases the sink runs on background thread.
    ///     By default, backed by <c>TestContext.Current.TestOutputHelper</c> during <see cref="XUnit3TestOutputSink.Emit"/> call.
    /// </summary>
    public ITestOutputHelper? TestOutputHelper { get; set; }

    /// <inheritdoc cref="ILogEventSink.Emit"/>
    public void Emit(LogEvent logEvent)
    {
        ArgumentNullException.ThrowIfNull(logEvent);

        using var stringWriter = new StringWriter();
        _messageTemplateTextFormatter.Format(logEvent, stringWriter);
        var message = stringWriter.ToString().Trim();
        (TestOutputHelper ?? TestContext.Current.TestOutputHelper)?.WriteLine(message);
    }
}
