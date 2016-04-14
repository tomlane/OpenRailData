namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleUnitOfWorkFactory
    {
        IScheduleUnitOfWork Create();
    }
}