using System;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Repository;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.UnitOfWork
{
    public class ScheduleUnitOfWork : IScheduleUnitOfWork
    {
        public IHeaderRecordRepository HeaderRecords { get; }
        public ITiplocRecordRepository TiplocRecords { get; }
        public IAssociationRecordRepository AssociationRecords { get; }
        public IScheduleRecordRepository ScheduleRecords { get; }
        public IScheduleLocationRecordRepository ScheduleLocationRecords { get; }
        
        public ScheduleUnitOfWork(IMongoDbClientFactory clientFactory)
        {
            if (clientFactory == null)
                throw new ArgumentNullException(nameof(clientFactory));

            var client = clientFactory.Create();
            var database = client.GetDatabase("NetworkRailSchedule");

            HeaderRecords = new HeaderMongoDbRepository(database);
            TiplocRecords = new TiplocMongoDbRepository(database);
            AssociationRecords = new AssociationMongoDbRepository(database);
            ScheduleRecords = new ScheduleMongoDbRepository(database);
            ScheduleLocationRecords = new ScheduleLocationMongoDbRepository();
        }

        public int Complete()
        {
            return 1;
        }

        public void Dispose() {  }
    }
}