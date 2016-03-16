namespace OpenRailData.Schedule.DataAccess.Core
{
    public interface IScheduleUnitOfWorkFactory
    {
        IScheduleUnitOfWork Create();
    }
}