using System.IO;
using Autofac;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json;
using OpenRailData.ScheduleStorage;
using OpenRailData.ScheduleStorage.EntityFramework;
using System.Linq;

namespace OpenRailData.NetworkRailScheduleBootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var containerBuilder = SchedulePropertyParsersContainerBuilder.Build();
            containerBuilder = JsonScheduleParsingContainerBuilder.Build(containerBuilder);
            containerBuilder = EntityFrameworkScheduleStorageContainerBuilder.Build(containerBuilder);

            var container = containerBuilder.Build();

            var scheduleParsingService = container.Resolve<IScheduleRecordParsingService>();
            var scheduleStorageService = container.Resolve<IScheduleRecordStorageService>();
            var scheduleDatabaseMigrator = container.Resolve<IScheduleDatabaseMigrator>();

            scheduleDatabaseMigrator.MigrateDatabase();

            var schedules =
                File.ReadAllLines(
                    @"C:\Users\Tom\OneDrive\RailData\JSON Schedule Extracts\CIF_EF_TOC_FULL_DAILY-toc-full");

            var parsedSchedule = scheduleParsingService.Parse(schedules).ToList();

            scheduleStorageService.Store(parsedSchedule);
        }
    }
}
