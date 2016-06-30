using System;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework.Converters
{
    public static class AssociationEntityGenerator
    {
        internal static AssociationRecordEntity RecordToEntity(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            return new AssociationRecordEntity
            {
                UniqueId = record.UniqueId,
                RecordIdentity = record.RecordIdentity,
                EndDate = record.EndDate,
                StartDate = record.StartDate,
                AssocLocationSuffix = record.AssocLocationSuffix,
                AssocDays = record.AssocDays,
                BaseLocationSuffix = record.BaseLocationSuffix,
                StpIndicator = record.StpIndicator,
                AssocTrainUid = record.AssocTrainUid,
                AssocType = record.AssocType,
                MainTrainUid = record.MainTrainUid,
                Location = record.Location,
                DiagramType = record.DiagramType,
                DateIndicator = record.DateIndicator,
                Category = record.Category
            };
        }

        internal static AssociationRecord EntityToRecord(AssociationRecordEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new AssociationRecord
            {
                UniqueId = entity.UniqueId,
                RecordIdentity = entity.RecordIdentity,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                AssocLocationSuffix = entity.AssocLocationSuffix,
                AssocDays = entity.AssocDays,
                BaseLocationSuffix = entity.BaseLocationSuffix,
                StpIndicator = entity.StpIndicator,
                AssocTrainUid = entity.AssocTrainUid,
                AssocType = entity.AssocType,
                MainTrainUid = entity.MainTrainUid,
                Location = entity.Location,
                DiagramType = entity.DiagramType,
                DateIndicator = entity.DateIndicator,
                Category = entity.Category
            };
        }
    }
}