namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public interface IScheduleContextConfigurationProvider
    {
        ScheduleContextConfiguration GetConfiguration();
    }

    public class StaticScheduleContextConfigurationProvider : IScheduleContextConfigurationProvider
    {
        public ScheduleContextConfiguration GetConfiguration()
        {
            return new ScheduleContextConfiguration
            {
                ConnectionString = @"Server=localhost\SQLSERVER2016RC1;Initial Catalog=RailDataEngine; Integrated Security=true;"
            };
        }
    }
}