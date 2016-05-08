using System;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.UnitOfWork
{
    public class ScheduleUnitOfWorkFactory : IScheduleUnitOfWorkFactory
    {
        private readonly IMongoDbClientFactory _clientFactory;

        public ScheduleUnitOfWorkFactory(IMongoDbClientFactory clientFactory)
        {
            if (clientFactory == null)
                throw new ArgumentNullException(nameof(clientFactory));

            _clientFactory = clientFactory;
        }

        public IScheduleUnitOfWork Create()
        {
            return new ScheduleUnitOfWork(_clientFactory);
        }
    }
}