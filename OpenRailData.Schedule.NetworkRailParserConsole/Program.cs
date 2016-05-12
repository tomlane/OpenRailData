using System;
using System.Linq;
using Microsoft.Practices.Unity;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleFetching;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Schedule.NetworkRailParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CifParserIocContainerBuilder.Build();

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
