using System;
using System.Data.Entity.Infrastructure;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.UnitOfWork
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