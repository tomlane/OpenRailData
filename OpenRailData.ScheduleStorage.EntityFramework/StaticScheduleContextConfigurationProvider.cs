namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public class StaticScheduleContextConfigurationProvider : IScheduleContextConfigurationProvider
    {
        public ScheduleContextConfiguration GetConfiguration()
        {
            return new ScheduleContextConfiguration
            {
                ConnectionString = @"Server=localhost\SQLSERVER2016;Initial Catalog=RailDataEngine; Integrated Security=true;"
            };
        }
    }
}