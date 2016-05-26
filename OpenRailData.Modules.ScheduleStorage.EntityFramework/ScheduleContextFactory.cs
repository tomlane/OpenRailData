using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenRailData.Configuration;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework
{
    public class ScheduleContextFactory : IDbContextFactory<ScheduleContext>
    {
        public ScheduleContext Create()
        {
            IScheduleDatabase db = new ScheduleDatabase(new ConfigConnectionStringProvider());
            return db.BuildContext() as ScheduleContext;
        }
    }
}
