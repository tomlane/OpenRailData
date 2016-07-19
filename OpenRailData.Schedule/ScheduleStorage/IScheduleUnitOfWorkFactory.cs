namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleUnitOfWorkFactory
    {
        IScheduleUnitOfWork Create();
    }
}