using OpenRailData.Darwin.Entites.Schedule;

namespace OpenRailData.Darwin
{
    public interface IDarwinScheduleProvider
    {
        DarwinSchedule GetSchedule();
    }
}