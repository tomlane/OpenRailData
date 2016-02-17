using System;
using System.Diagnostics;
using System.Linq;
using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.NLog;
using Microsoft.Practices.Unity;
using OpenRailData.Schedule.NetworkRailScheduleParser;

namespace OpenRailData.Schedule.NetworkRailParserConsole
{
    class Program
    {
        private static ILog Logger; 

        static void Main(string[] args)
        {
            var loggingSettings = new NameValueCollection
            {
                ["configType"] = "FILE",
                ["configFile"] = "NLog.config"
            };

            LogManager.Adapter = new NLogLoggerFactoryAdapter(loggingSettings);

            Logger = LogManager.GetLogger("NetworkRail.ScheduleParser.Console");
            
            if (Logger.IsTraceEnabled)
                Logger.Trace("Starting up...");

            const string url = "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-tue.CIF.gz";

            var start = Process.GetCurrentProcess().TotalProcessorTime;

            var container = CifParserIocContainerBuilder.Build();

            if (Logger.IsTraceEnabled)
                Logger.Trace("Dependency Injection container built.");

            var scheduleManager = container.Resolve<IScheduleManager>();

            var entites = scheduleManager.GetRecordsByScheduleFileUrl(url).ToList();
            
            var end = Process.GetCurrentProcess().TotalProcessorTime;

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Record Parsing Time: {(end - start).TotalMilliseconds} ms.");
                Logger.Trace($"Records Parsed: {entites.Count}");
                

            start = Process.GetCurrentProcess().TotalProcessorTime;

            entites = scheduleManager.MergeScheduleRecords(entites).ToList();

            end = Process.GetCurrentProcess().TotalProcessorTime;

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Record Merging Time: {(end - start).TotalMilliseconds} ms.");
                Logger.Trace($"Merged Records Count: {entites.Count}");
                Logger.Trace("Schedule record processing complete. Ready for storage.");

            start = Process.GetCurrentProcess().TotalProcessorTime;

            scheduleManager.SaveScheduleRecords(entites);

            end = Process.GetCurrentProcess().TotalProcessorTime;

            if (Logger.IsTraceEnabled)
                Logger.Trace("Schedule storage complete.");
                Logger.Trace($"Storage Processing Time: {(end - start).TotalMilliseconds} ms.");

            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
