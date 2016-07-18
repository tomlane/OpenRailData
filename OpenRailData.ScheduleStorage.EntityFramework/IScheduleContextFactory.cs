namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public interface IScheduleContextFactory
    {
        ScheduleContext Create();
    }
}