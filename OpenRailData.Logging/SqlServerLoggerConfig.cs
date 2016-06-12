using System.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace OpenRailData.Logging
{
    public static class SqlServerLoggerConfig
    {
        public static ILogger Create()
        {
            var columnOptions = new ColumnOptions();

            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);

            return new LoggerConfiguration().WriteTo.MSSqlServer(ConfigurationManager.ConnectionStrings["Logging"].ConnectionString, "Logs", autoCreateSqlTable: true, columnOptions: columnOptions).CreateLogger();
        }
    }
}