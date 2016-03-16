﻿using System;
using Common.Logging;
using OpenRailData.Schedule.DataAccess.Core;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public class ScheduleAmendScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILog Logger = LogManager.GetLogger("RecordStorage.Schedule.Amend");
        
        public ScheduleAmendScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.BSR;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.ScheduleRecords.AmendRecord(record as ScheduleRecord);

                unitOfWork.Complete();
            }

            if (Logger.IsTraceEnabled)
                Logger.Trace("Processed a Basic Schedule Amend Record.");
        }
    }
}