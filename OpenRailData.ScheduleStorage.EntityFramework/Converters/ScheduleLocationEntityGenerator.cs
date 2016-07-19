using System;
using OpenRailData.Schedule.Entities;
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
                OrderTime = entity.OrderTime,
                Pass = entity.Pass,
                Path = entity.Path,
                PathingAllowance = entity.PathingAllowance,
                PerformanceAllowance = entity.PerformanceAllowance,
                Platform = entity.Platform,
                PublicArrival = entity.PublicArrival,
                PublicDeparture = entity.PublicDeparture,
                Tiploc = entity.Tiploc,
                TiplocSuffix = entity.TiplocSuffix,
                WorkingArrival = entity.WorkingArrival,
                WorkingDeparture = entity.WorkingDeparture
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
                OrderTime = record.OrderTime,
                Pass = record.Pass,
                Path = record.Path,
                PathingAllowance = record.PathingAllowance,
                PerformanceAllowance = record.PerformanceAllowance,
                Platform = record.Platform,
                PublicArrival = record.PublicArrival,
                PublicDeparture = record.PublicDeparture,
                Tiploc = record.Tiploc,
                TiplocSuffix = record.TiplocSuffix,
                WorkingArrival = record.WorkingArrival,
                WorkingDeparture = record.WorkingDeparture
            };
        }
    }
}