using System;
using Microsoft.Extensions.Options;

namespace OpenRailData.ScheduleStorage.EntityFramework.UnitOfWork
{
    public class ScheduleUnitOfWorkFactory : IScheduleUnitOfWorkFactory
    {
        private readonly IScheduleContextFactory _contextFactory;
        private readonly IOptions<ScheduleContextOptions> _options;

        public ScheduleUnitOfWorkFactory(IScheduleContextFactory contextFactory, IOptions<ScheduleContextOptions> options)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _contextFactory = contextFactory;
            _options = options;
        }

        public IScheduleUnitOfWork Create()
        {
            return new ScheduleUnitOfWork(_contextFactory.Create(_options));
        }
    }
}