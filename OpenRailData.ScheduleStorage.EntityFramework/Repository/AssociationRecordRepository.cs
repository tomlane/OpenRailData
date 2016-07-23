﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class AssociationRecordRepository : IAssociationRecordRepository
    {
        private readonly IScheduleContext _context;

        public AssociationRecordRepository(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }
        
        public Task InsertRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = AssociationEntityGenerator.RecordToEntity(record);

            _context.GetSet<AssociationRecordEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task InsertMultipleRecords(IEnumerable<AssociationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entites = records.Select(AssociationEntityGenerator.RecordToEntity).ToList();

            _context.GetSet<AssociationRecordEntity>().AddRange(entites);

            return Task.CompletedTask;
        }

        public async Task AmendRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = await _context.GetSet<AssociationRecordEntity>().FirstOrDefaultAsync(x => x.UniqueId== record.UniqueId);

            if (currentRecord != null)
            {
                var entity = AssociationEntityGenerator.RecordToEntity(record);

                _context.GetSet<AssociationRecordEntity>().Remove(currentRecord);

                _context.GetSet<AssociationRecordEntity>().Add(entity);
            }
        }

        public Task DeleteRecord(AssociationRecord record)
        {
            throw new NotImplementedException();
        }
    }
}