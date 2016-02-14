namespace OpenRailData.Schedule.NetworkRailScheduleDatabase
{
    public interface IScheduleDatabase
    {
        IScheduleContext DbContext { get; set; }
        IScheduleContext BuildContext();
    }
}
