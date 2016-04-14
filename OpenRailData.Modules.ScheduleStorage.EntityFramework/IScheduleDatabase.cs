namespace OpenRailData.Modules.ScheduleStorage.EntityFramework
{
    public interface IScheduleDatabase
    {
        IScheduleContext DbContext { get; set; }
        IScheduleContext BuildContext();
    }
}
