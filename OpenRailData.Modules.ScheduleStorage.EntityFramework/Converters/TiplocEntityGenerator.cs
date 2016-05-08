﻿using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters
{
    public class TiplocEntityGenerator
    {
        internal static TiplocRecordEntity RecordToEntity(TiplocRecord record)
        {
            var tiplocRecordEntity = TiplocMapperConfiguration.RecordToEntity().Map<TiplocRecordEntity>(record);

            return tiplocRecordEntity;
        }

        internal static TiplocRecord EntityToRecord(TiplocRecordEntity entity)
        {
            var tiplocRecord = TiplocMapperConfiguration.EntityToRecord().Map<TiplocRecord>(entity);

            return tiplocRecord;
        }
    }
}