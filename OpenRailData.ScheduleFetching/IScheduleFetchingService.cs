using System.Collections.Generic;

namespace OpenRailData.ScheduleFetching
{
    public interface IScheduleFetchingService
    {
        IEnumerable<string> FetchSchedule(ScheduleType scheduleType, bool useCachedFile = true);

        void ClearCache();
    }
}