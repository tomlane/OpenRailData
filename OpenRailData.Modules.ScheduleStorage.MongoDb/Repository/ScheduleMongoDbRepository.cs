using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Converters;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class ScheduleMongoDbRepository : IScheduleRecordRepository
    {
        private readonly IMongoCollection<ScheduleDocument> _collection;

        public ScheduleMongoDbRepository(IMongoDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _collection = database.GetCollection<ScheduleDocument>("Schedules");
        }

        public void InsertRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = ScheduleEntityGenerator.RecordToDocument(record);

            _collection.InsertOne(document);
        }

        public void AmendRecord(ScheduleRecord record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _collection.DeleteOne(x =>
                x.TrainUid == record.TrainUid &&
                x.DateRunsFrom == record.DateRunsFrom &&
                x.StpIndicator == record.StpIndicator);
        }

        public async Task InsertRecordAsync(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = ScheduleEntityGenerator.RecordToDocument(record);

            await _collection.InsertOneAsync(document);
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<ScheduleRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task AmendRecordAsync(ScheduleRecord record)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRecordAsync(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            await _collection.DeleteOneAsync(x =>
                x.TrainUid == record.TrainUid &&
                x.DateRunsFrom == record.DateRunsFrom &&
                x.StpIndicator == record.StpIndicator);
        }
    }
}