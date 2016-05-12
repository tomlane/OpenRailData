using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb
{
    public class MongoDbBulkCreateStorageService : IScheduleRecordStorageService
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public MongoDbBulkCreateStorageService(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void StoreScheduleRecords(IEnumerable<IScheduleRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var recordList = records as IList<IScheduleRecord> ?? records.ToList();

            var headerRecord = recordList.First(x => x.RecordIdentity == ScheduleRecordType.HD) as HeaderRecord;

            var associationRecords = recordList.Where(x => x.RecordIdentity == ScheduleRecordType.AAN).Select(record => record as AssociationRecord).AsEnumerable();
            var scheduleRecords = recordList.Where(x => x.RecordIdentity == ScheduleRecordType.BSN).Select(record => record as ScheduleRecord).AsEnumerable();
            var tiplocRecords = recordList.Where(x => x.RecordIdentity == ScheduleRecordType.TI).Select(record => record as TiplocRecord).AsEnumerable();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.HeaderRecords.InsertRecord(headerRecord);
                unitOfWork.AssociationRecords.InsertMultipleRecordsAsync(associationRecords);
                unitOfWork.ScheduleRecords.InsertMultipleRecordsAsync(scheduleRecords);
                unitOfWork.TiplocRecords.InsertMultipleRecordsAsync(tiplocRecords);
            }
        }
    }
}