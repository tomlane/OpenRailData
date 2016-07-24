using System;
using NodaTime;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework.Converters
{
    internal static class ScheduleLocationEntityGenerator
    {
        public static ScheduleLocationRecord EntityToRecord(ScheduleLocationRecordEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new ScheduleLocationRecord
            {
                RecordIdentity = entity.RecordIdentity,
                EngineeringAllowance = entity.EngineeringAllowance,
                Line = entity.Line,
                LocationActivity = entity.LocationActivity,
                LocationActivityString = entity.LocationActivityString,
                OrderTime = ScheduleLocationTimeParser.ParseLocationTimeString(entity.OrderTime),
                Pass = ScheduleLocationTimeParser.ParseLocationTimeString(entity.Pass),
                Path = entity.Path,
                PathingAllowance = entity.PathingAllowance,
                PerformanceAllowance = entity.PerformanceAllowance,
                Platform = entity.Platform,
                PublicArrival = ScheduleLocationTimeParser.ParseLocationTimeString(entity.PublicArrival),
                PublicDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(entity.PublicDeparture),
                Tiploc = entity.Tiploc,
                TiplocSuffix = entity.TiplocSuffix,
                WorkingArrival = ScheduleLocationTimeParser.ParseLocationTimeString(entity.WorkingArrival),
                WorkingDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(entity.WorkingDeparture)
            };

        }

        public static ScheduleLocationRecordEntity RecordToEntity(ScheduleLocationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            return new ScheduleLocationRecordEntity
            {
                RecordIdentity = record.RecordIdentity,
                EngineeringAllowance = record.EngineeringAllowance,
                Line = record.Line,
                LocationActivity = record.LocationActivity,
                LocationActivityString = record.LocationActivityString,
                OrderTime = ScheduleLocationTimeParser.ParseLocalTimeInstance(record.OrderTime),
                Pass = ScheduleLocationTimeParser.ParseLocalTimeInstance(record.Pass),
                Path = record.Path,
                PathingAllowance = record.PathingAllowance,
                PerformanceAllowance = record.PerformanceAllowance,
                Platform = record.Platform,
                PublicArrival = ScheduleLocationTimeParser.ParseLocalTimeInstance(record.PublicArrival),
                PublicDeparture = ScheduleLocationTimeParser.ParseLocalTimeInstance(record.PublicDeparture),
                Tiploc = record.Tiploc,
                TiplocSuffix = record.TiplocSuffix,
                WorkingArrival = ScheduleLocationTimeParser.ParseLocalTimeInstance(record.WorkingArrival),
                WorkingDeparture = ScheduleLocationTimeParser.ParseLocalTimeInstance(record.WorkingDeparture)
            };
        }
    }
}