using OpenRailData.Domain.DarwinSchedule;

namespace OpenRailData.Darwin.ScheduleParsing
{
    public interface IDarwinScheduleParser
    {
        DarwinSchedule ParseSchedule(string rawSchedule);
    }
}