﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Converters;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class TiplocMongoDbRepository : ITiplocRecordRepository
    {
        private readonly IMongoCollection<TiplocDocument> _collection;

        public TiplocMongoDbRepository(IMongoDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _collection = database.GetCollection<TiplocDocument>("Tiplocs");
        }

        public void InsertRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = TiplocEntityGenerator.RecordToDocument(record);

            _collection.InsertOne(document);
        }

        public void AmendRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = TiplocEntityGenerator.RecordToDocument(record);

            throw new NotImplementedException();
        }

        public void DeleteRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _collection.DeleteOne(x => x.TiplocCode == record.TiplocCode);
        }

        public void AmendLocationName(string locationName, string tiplocCode)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentNullException(nameof(locationName));

            if (string.IsNullOrWhiteSpace(tiplocCode))
                throw new ArgumentNullException(nameof(tiplocCode));

            throw new NotImplementedException();
        }

        public async Task InsertRecordAsync(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = TiplocEntityGenerator.RecordToDocument(record);

            await _collection.InsertOneAsync(document);
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<TiplocRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task AmendRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRecordAsync(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            await _collection.DeleteOneAsync(x => x.TiplocCode == record.TiplocCode);
        }

        public Task AmendLocationNameAsync(string locationName, string tiplocCode)
        {
            throw new NotImplementedException();
        }
    }
}