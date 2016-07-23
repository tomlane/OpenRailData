using System;
using System.IO;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.Schedule.ScheduleStorage;
using OpenRailData.ScheduleStorage.EntityFramework;
using System.Linq;

namespace OpenRailData.BootstrapperJobs
{
    public class NetworkRailScheduleScheduleBootstrapperJob : INetworkRailScheduleDataBootstrapperJob
    {
        private readonly IScheduleRecordParsingService _scheduleRecordParsingService;
        private readonly IScheduleRecordStorageService _scheduleRecordStorageService;
        private readonly IScheduleDatabaseMigrator _databaseMigrator;

        public NetworkRailScheduleScheduleBootstrapperJob(IScheduleRecordParsingService scheduleRecordParsingService, IScheduleRecordStorageService scheduleRecordStorageService, 
            IScheduleDatabaseMigrator databaseMigrator)
        {
            if (scheduleRecordParsingService == null)
                throw new ArgumentNullException(nameof(scheduleRecordParsingService));
            if (scheduleRecordStorageService == null)
                throw new ArgumentNullException(nameof(scheduleRecordStorageService));
            if (databaseMigrator == null)
                throw new ArgumentNullException(nameof(databaseMigrator));

            _scheduleRecordParsingService = scheduleRecordParsingService;
            _scheduleRecordStorageService = scheduleRecordStorageService;
            _databaseMigrator = databaseMigrator;
        }

        public void Execute()
        {
            _databaseMigrator.MigrateDatabase();

            var schedules =
                File.ReadAllLines(
                    @"C:\Users\Tom\OneDrive\RailData\JSON Schedule Extracts\CIF_ALL_FULL_DAILY_toc-full");

            var parsedSchedule = _scheduleRecordParsingService.Parse(schedules).ToList();

            _scheduleRecordStorageService.Store(parsedSchedule);
        }
    }
}