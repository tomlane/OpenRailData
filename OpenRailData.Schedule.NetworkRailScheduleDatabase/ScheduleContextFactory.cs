using System.Data.Entity.Infrastructure;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleDatabase
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
