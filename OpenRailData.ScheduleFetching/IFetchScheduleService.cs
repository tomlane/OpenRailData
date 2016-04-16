using System.Collections.Generic;

namespace OpenRailData.ScheduleFetching
{
    public interface IFetchScheduleService
    {
        IEnumerable<string> FetchSchedule(ScheduleType scheduleType);
    }
}