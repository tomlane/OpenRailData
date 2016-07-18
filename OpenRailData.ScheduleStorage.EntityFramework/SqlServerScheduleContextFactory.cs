using Microsoft.EntityFrameworkCore;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public class SqlServerScheduleContextFactory : IScheduleContextFactory
    {
        private readonly ScheduleContextConfiguration _configuration;

        public SqlServerScheduleContextFactory(IScheduleContextConfigurationProvider configurationProvider)
        {
            _configuration = configurationProvider.GetConfiguration();
        }

        public ScheduleContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ScheduleContext>();

            optionsBuilder.UseSqlServer(_configuration.ConnectionString);

            return new ScheduleContext(optionsBuilder.Options);
        }
    }
}