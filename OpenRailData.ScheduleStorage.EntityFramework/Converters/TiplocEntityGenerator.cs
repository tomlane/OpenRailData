using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework.Converters
{
    public static class TiplocEntityGenerator
    {
        internal static TiplocRecordEntity RecordToEntity(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            return new TiplocRecordEntity
            {
                RecordIdentity = record.RecordIdentity,
                CrsCode = record.CrsCode,
                Stanox = record.Stanox,
                CapriDescription = record.CapriDescription,
                TiplocCode = record.TiplocCode,
                Nalco = record.Nalco,
                CapitalsIdentification = record.CapitalsIdentification,
                LocationName = record.LocationName,
                Nlc = record.Nlc,
                TpsDescription = record.TpsDescription,
                OldTiploc = record.OldTiploc,
                PoMcbCode = record.PoMcbCode
            };
        }

        internal static TiplocRecord EntityToRecord(TiplocRecordEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new TiplocRecord
            {
                RecordIdentity = entity.RecordIdentity,
                CrsCode = entity.CrsCode,
                Stanox = entity.Stanox,
                CapriDescription = entity.CapriDescription,
                TiplocCode = entity.TiplocCode,
                Nalco = entity.Nalco,
                CapitalsIdentification = entity.CapitalsIdentification,
                LocationName = entity.LocationName,
                Nlc = entity.Nlc,
                TpsDescription = entity.TpsDescription,
                OldTiploc = entity.OldTiploc,
                PoMcbCode = entity.PoMcbCode
            };
        }
    }
}