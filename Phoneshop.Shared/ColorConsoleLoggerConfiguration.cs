using Microsoft.Extensions.Logging;

namespace Phoneshop.Shared
{
    public sealed class ColorConsoleLoggerConfiguration
    {
        public int EventId { get; set; }
        public Dictionary<LogLevel, ConsoleColor> LogLevelToColorMap { get; set; } = new()
        {
            [LogLevel.Information] = ConsoleColor.Green,
            [LogLevel.Warning] = ConsoleColor.Yellow,
            [LogLevel.Error] = ConsoleColor.Red,
            [LogLevel.Critical] = ConsoleColor.DarkRed
        };
    }
}
