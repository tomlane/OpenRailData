using Serilog;

namespace OpenRailData.Logging
{
    public static class ConsoleLoggerConfig
    {
        public static ILogger Create()
        {
            return new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }
    }
}