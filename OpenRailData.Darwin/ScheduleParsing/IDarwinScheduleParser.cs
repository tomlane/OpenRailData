using OpenRailData.Darwin.Entites.Schedule;

namespace OpenRailData.Darwin.ScheduleParsing
{
    public interface IDarwinScheduleParser
    {
        DarwinSchedule ParseSchedule(string rawSchedule);
    }
}