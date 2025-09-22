using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Core;
using Xunit;

namespace Serilog.Sinks.XUnit3;

public sealed class XUnit3TestOutputSink(
    string outputTemplate = XUnit3TestOutputSink.DefaultTemplate,
    IFormatProvider? formatProvider = null) : ILogEventSink
{
    private const string DefaultTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{Exception}";

    private readonly MessageTemplateTextFormatter _messageTemplateTextFormatter = new(outputTemplate, formatProvider);

    public ITestOutputHelper? TestOutputHelper { get; set; }

    public void Emit(LogEvent logEvent)
    {
        ArgumentNullException.ThrowIfNull(logEvent);

        using var stringWriter = new StringWriter();
        _messageTemplateTextFormatter.Format(logEvent, stringWriter);
        var message = stringWriter.ToString().Trim();
        (TestOutputHelper ?? TestContext.Current.TestOutputHelper)?.WriteLine(message);
    }
}
