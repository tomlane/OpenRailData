namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public interface IScheduleContextConfigurationProvider
    {
        ScheduleContextConfiguration GetConfiguration();
    }
}