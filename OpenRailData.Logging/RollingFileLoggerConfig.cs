using Serilog;

namespace OpenRailData.Logging
{
    public static class RollingFileLoggerConfig
    {
        public static ILogger Create()
        {
            return new LoggerConfiguration().WriteTo.RollingFile("Log-{Date}.log").CreateLogger();
        }
    }
}