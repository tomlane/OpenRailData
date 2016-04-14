using System;
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
            
            if (Logger.IsInfoEnabled)
                Logger.Info("Starting up...");

            const string url = "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-sat.CIF.gz";

            var container = CifParserIocContainerBuilder.Build();

            if (Logger.IsInfoEnabled)
                Logger.Info("Dependency Injection container built.");

            var scheduleManager = container.Resolve<IScheduleManager>();

            var entites = scheduleManager.GetRecordsByScheduleFileUrl(url).ToList();
            
            entites = scheduleManager.MergeScheduleRecords(entites).ToList();

            scheduleManager.SaveScheduleRecords(entites);

            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
