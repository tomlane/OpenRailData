using System;
using System.Linq;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework.Converters
{
    public static class ScheduleEntityGenerator
    {
        internal static ScheduleRecordEntity RecordToEntity(ScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = new ScheduleRecordEntity
            {
                RecordIdentity = record.RecordIdentity,
                UniqueId = record.UniqueId,
                EndDate = record.EndDate,
                StartDate = record.StartDate,
                SeatingClass = record.SeatingClass,
                ServiceBranding = record.ServiceBranding,
                StpIndicator = record.StpIndicator,
                AtocCode = record.AtocCode,
                AtsCode = record.AtsCode,
                BankHolidayRunning = record.BankHolidayRunning,
                CateringCode = record.CateringCode,
                ConnectionIndicator = record.ConnectionIndicator,
                CourseIndicator = record.CourseIndicator,
                DataSource = record.DataSource,
                HeadCode = record.HeadCode,
                OperatingCharacteristics = record.OperatingCharacteristics,
                OperatingCharacteristicsString = record.OperatingCharacteristicsString,
                PortionId = record.PortionId,
                PowerType = record.PowerType,
                Reservations = record.Reservations,
                Rsid = record.Rsid,
                RunningDays = record.RunningDays,
                ServiceTypeFlags = record.ServiceTypeFlags,
                Sleepers = record.Sleepers,
                Speed = record.Speed,
                TimingLoad = record.TimingLoad,
                TrainCategory = record.TrainCategory,
                TrainIdentity = record.TrainIdentity,
                TrainServiceCode = record.TrainServiceCode,
                TrainStatus = record.TrainStatus,
                TrainUid = record.TrainUid,
                UicCode = record.UicCode
            };

            if (record.ScheduleLocations != null && record.ScheduleLocations.Any())
                entity.ScheduleLocations = record.ScheduleLocations.Select(ScheduleLocationEntityGenerator.RecordToEntity).ToList();
            
            return entity;
        }

        internal static ScheduleRecord EntityToRecord(ScheduleRecordEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var record = new ScheduleRecord
            {
                RecordIdentity = entity.RecordIdentity,
                UniqueId = entity.UniqueId,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                SeatingClass = entity.SeatingClass,
                ServiceBranding = entity.ServiceBranding,
                StpIndicator = entity.StpIndicator,
                AtocCode = entity.AtocCode,
                AtsCode = entity.AtsCode,
                BankHolidayRunning = entity.BankHolidayRunning,
                CateringCode = entity.CateringCode,
                ConnectionIndicator = entity.ConnectionIndicator,
                CourseIndicator = entity.CourseIndicator,
                DataSource = entity.DataSource,
                HeadCode = entity.HeadCode,
                OperatingCharacteristics = entity.OperatingCharacteristics,
                OperatingCharacteristicsString = entity.OperatingCharacteristicsString,
                PortionId = entity.PortionId,
                PowerType = entity.PowerType,
                Reservations = entity.Reservations,
                Rsid = entity.Rsid,
                RunningDays = entity.RunningDays,
                ServiceTypeFlags = entity.ServiceTypeFlags,
                Sleepers = entity.Sleepers,
                Speed = entity.Speed,
                TimingLoad = entity.TimingLoad,
                TrainCategory = entity.TrainCategory,
                TrainIdentity = entity.TrainIdentity,
                TrainServiceCode = entity.TrainServiceCode,
                TrainStatus = entity.TrainStatus,
                TrainUid = entity.TrainUid,
                UicCode = entity.UicCode
            };

            if (entity.ScheduleLocations != null && entity.ScheduleLocations.Any())
                record.ScheduleLocations = entity.ScheduleLocations.Select(ScheduleLocationEntityGenerator.EntityToRecord).ToList();
            
            return record;
        }
    }
}