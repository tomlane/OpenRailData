using System;
using System.Data.Entity.Infrastructure;
using OpenRailData.Schedule.DataAccess.Core;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.DataAccess.EntityFramework
{
    public class ScheduleUnitOfWorkFactory : IScheduleUnitOfWorkFactory
    {
        private readonly IDbContextFactory<ScheduleContext> _contextFactory;

        public ScheduleUnitOfWorkFactory(IDbContextFactory<ScheduleContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public IScheduleUnitOfWork Create()
        {
            return new ScheduleUnitOfWork(_contextFactory.Create());
        }
    }
}