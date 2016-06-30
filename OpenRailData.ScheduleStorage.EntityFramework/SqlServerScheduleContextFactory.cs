using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public class SqlServerScheduleContextFactory : IScheduleContextFactory
    {
        public ScheduleContext Create(IOptions<ScheduleContextOptions> options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ScheduleContext>();

            optionsBuilder.UseSqlServer(options.Value.ConnectionString);

            return new ScheduleContext(optionsBuilder.Options);
        }
    }
}