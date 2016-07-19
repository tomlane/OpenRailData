using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework.Converters
{
    public static class HeaderEntityGenerator
    {
        internal static HeaderRecordEntity RecordToEntity(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            return new HeaderRecordEntity
            {
                RecordIdentity = record.RecordIdentity,
                DateOfExtract = record.DateOfExtract,
                CurrentFileRef = record.CurrentFileRef,
                CifSoftwareVersion = record.CifSoftwareVersion,
                ExtractUpdateType = record.ExtractUpdateType,
                LastFileRef = record.LastFileRef,
                MainFrameExtractDate = record.MainFrameExtractDate,
                MainFrameIdentity = record.MainFrameIdentity,
                MainFrameUser = record.MainFrameUser,
                TimeOfExtract = record.TimeOfExtract,
                UserExtractEndDate = record.UserExtractEndDate,
                UserExtractStartDate = record.UserExtractStartDate
            };
        }

        internal static HeaderRecord EntityToRecord(HeaderRecordEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new HeaderRecord
            {
                RecordIdentity = entity.RecordIdentity,
                DateOfExtract = entity.DateOfExtract,
                CurrentFileRef = entity.CurrentFileRef,
                CifSoftwareVersion = entity.CifSoftwareVersion,
                ExtractUpdateType = entity.ExtractUpdateType,
                LastFileRef = entity.LastFileRef,
                MainFrameExtractDate = entity.MainFrameExtractDate,
                MainFrameIdentity = entity.MainFrameIdentity,
                MainFrameUser = entity.MainFrameUser,
                TimeOfExtract = entity.TimeOfExtract,
                UserExtractEndDate = entity.UserExtractEndDate,
                UserExtractStartDate = entity.UserExtractStartDate
            };
        }
    }
}