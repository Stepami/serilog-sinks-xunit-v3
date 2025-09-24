namespace Serilog.Sinks.XUnit3;

/// <summary>
///     <see cref="XUnit3TestOutputSink"/> configuration settings.
/// </summary>
/// <param name="OutputTemplate">
///     Format of the log message.
///     Default is <see cref="XUnit3TestOutputSinkOptions.DefaultTemplate"/>.</param>
/// <param name="FormatProvider">Format source.</param>
public sealed record XUnit3TestOutputSinkOptions(
    string OutputTemplate = XUnit3TestOutputSinkOptions.DefaultTemplate,
    IFormatProvider? FormatProvider = null)
{
    private const string DefaultTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{Exception}";
}