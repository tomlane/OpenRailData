using System;
using System.Linq;
using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.NLog;
using Microsoft.Practices.Unity;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleFetching;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleStorage;

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
            
            if (Logger.IsInfoEnabled)
                Logger.Info("Starting up...");

            var container = CifParserIocContainerBuilder.Build();

            if (Logger.IsInfoEnabled)
                Logger.Info("Dependency Injection container built.");

            var scheduleFetchService = container.Resolve<IScheduleFetchingService>();
            var scheduleParseService = container.Resolve<IScheduleRecordParsingService>();
            var scheduleStorageService = container.Resolve<IScheduleRecordStorageService>();

            var recordMerger = container.Resolve<IScheduleRecordMerger>();

            var records = recordMerger.MergeScheduleRecords(scheduleParseService.ParseScheduleRecords(scheduleFetchService.FetchSchedule(ScheduleType.Full))).ToList();

            scheduleStorageService.StoreScheduleRecords(records);

            Console.WriteLine("Parsed {0} records", records.Count);

            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
