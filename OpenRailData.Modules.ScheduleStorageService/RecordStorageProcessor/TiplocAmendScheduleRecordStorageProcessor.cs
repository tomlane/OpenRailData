﻿using System;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorageService.RecordStorageProcessor
{
    public class TiplocAmendScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public TiplocAmendScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TA;

        public void StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.TiplocRecords.AmendRecord(record as TiplocRecord);

                unitOfWork.Complete();
            }
        }
    }
}