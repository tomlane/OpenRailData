using System;
using System.Collections.Generic;
using System.IO;
using OpenRailData.Configuration;

namespace OpenRailData.ScheduleFetching
{
    public class FileScheduleFetchingService : IScheduleFetchingService
    {
        private readonly IConfigManager _configManager;

        public FileScheduleFetchingService(IConfigManager configManager)
        {
            if (configManager == null)
                throw new ArgumentNullException(nameof(configManager));

            _configManager = configManager;
        }

        public IEnumerable<string> FetchSchedule(ScheduleType scheduleType, bool useCachedFile = true)
        {
            return File.ReadAllLines(_configManager.GetConfigSetting("ScheduleFileLocation"));
        }

        public void ClearCache()
        {
        }
    }
}