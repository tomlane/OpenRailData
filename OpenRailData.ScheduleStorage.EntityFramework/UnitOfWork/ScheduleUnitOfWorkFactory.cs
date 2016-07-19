using System;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.ScheduleStorage.EntityFramework.UnitOfWork
{
    public class ScheduleUnitOfWorkFactory : IScheduleUnitOfWorkFactory
    {
        private readonly IScheduleContextFactory _contextFactory;

        public ScheduleUnitOfWorkFactory(IScheduleContextFactory contextFactory)
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