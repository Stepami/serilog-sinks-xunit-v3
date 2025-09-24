using Microsoft.Extensions.Options;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Xunit;

namespace Serilog.Sinks.XUnit3;

/// <summary>
///     Extensions to configure Serilog logger to write logs to xUnit.v3 test output.
/// </summary>
public static class XUnit3TestsOutputSinkExtensions
{
    /// <summary>
    ///     Writes log events to <see cref="ITestOutputHelper" />
    /// </summary>
    /// <param name="sink">The sink registered in DI</param>
    /// <param name="loggerSinkConfiguration">Logger sink configuration.</param>
    /// <param name="restrictedToMinimumLevel">
    ///     The minimum level for
    ///     events passed through the sink. Ignored when <paramref name="levelSwitch" /> is specified.
    /// </param>
    /// <param name="levelSwitch">
    ///     A switch allowing the pass-through minimum level
    ///     to be changed at runtime.
    /// </param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration XUnit3TestOutput(
        this LoggerSinkConfiguration loggerSinkConfiguration,
        XUnit3TestOutputSink? sink = null,
        LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
        LoggingLevelSwitch? levelSwitch = null) =>
        loggerSinkConfiguration.Sink(
            sink ?? new XUnit3TestOutputSink(Options.Create(new XUnit3TestOutputSinkOptions())),
            restrictedToMinimumLevel,
            levelSwitch);

    /// <summary>
    ///     Writes log events to <see cref="ITestOutputHelper" />
    /// </summary>
    /// <param name="outputTemplate">Format of the log message</param>
    /// <param name="formatProvider">Format source</param>
    /// <param name="loggerSinkConfiguration">Logger sink configuration.</param>
    /// <param name="restrictedToMinimumLevel">
    ///     The minimum level for
    ///     events passed through the sink. Ignored when <paramref name="levelSwitch" /> is specified.
    /// </param>
    /// <param name="levelSwitch">
    ///     A switch allowing the pass-through minimum level
    ///     to be changed at runtime.
    /// </param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration XUnit3TestOutput(
        this LoggerSinkConfiguration loggerSinkConfiguration,
        string outputTemplate,
        IFormatProvider? formatProvider = null,
        LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
        LoggingLevelSwitch? levelSwitch = null) =>
        loggerSinkConfiguration.XUnit3TestOutput(
            Options.Create(new XUnit3TestOutputSinkOptions(outputTemplate, formatProvider)),
            restrictedToMinimumLevel,
            levelSwitch);

    /// <summary>
    ///     Writes log events to <see cref="ITestOutputHelper" />
    /// </summary>
    /// <param name="options">Configuration settings.</param>
    /// <param name="loggerSinkConfiguration">Logger sink configuration.</param>
    /// <param name="restrictedToMinimumLevel">
    ///     The minimum level for
    ///     events passed through the sink. Ignored when <paramref name="levelSwitch" /> is specified.
    /// </param>
    /// <param name="levelSwitch">
    ///     A switch allowing the pass-through minimum level
    ///     to be changed at runtime.
    /// </param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration XUnit3TestOutput(
        this LoggerSinkConfiguration loggerSinkConfiguration,
        IOptions<XUnit3TestOutputSinkOptions> options,
        LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
        LoggingLevelSwitch? levelSwitch = null) =>
        loggerSinkConfiguration.XUnit3TestOutput(
            new XUnit3TestOutputSink(options), restrictedToMinimumLevel, levelSwitch);
}