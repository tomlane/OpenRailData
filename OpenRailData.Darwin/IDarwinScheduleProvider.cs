using OpenRailData.Domain.DarwinSchedule;

namespace OpenRailData.Darwin
{
    public interface IDarwinScheduleProvider
    {
        DarwinSchedule GetSchedule();
    }
}