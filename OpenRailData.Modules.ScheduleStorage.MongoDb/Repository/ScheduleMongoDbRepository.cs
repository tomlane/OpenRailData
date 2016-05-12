using System;
using System.Collections.Generic;
using System.Linq;
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
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = ScheduleEntityGenerator.RecordToDocument(record);

            _collection.UpdateOne(x =>
                x.TrainUid == record.TrainUid &&
                x.DateRunsFrom == record.DateRunsFrom &&
                x.StpIndicator == record.StpIndicator,
                new ObjectUpdateDefinition<ScheduleDocument>(document));
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

        public async Task InsertMultipleRecordsAsync(IEnumerable<ScheduleRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var documents = records.Select(ScheduleEntityGenerator.RecordToDocument).ToList();

            await _collection.InsertManyAsync(documents);
        }

        public async Task AmendRecordAsync(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = ScheduleEntityGenerator.RecordToDocument(record);

            await _collection.UpdateOneAsync(x =>
                x.TrainUid == record.TrainUid &&
                x.DateRunsFrom == record.DateRunsFrom &&
                x.StpIndicator == record.StpIndicator,
                new ObjectUpdateDefinition<ScheduleDocument>(document));
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