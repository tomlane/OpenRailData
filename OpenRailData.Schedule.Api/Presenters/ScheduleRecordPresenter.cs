using OpenRailData.Schedule.Api.ResponseModels;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.Api.Presenters
{
    internal static class ScheduleRecordPresenter
    {
        public static ScheduleRecordSearchResponseModel PresentScheduleRecord(ScheduleRecord record)
        {
            return new ScheduleRecordSearchResponseModel
            {
                ScheduleStartDate = record.StartDate,
                TrainUid = record.TrainUid,
                BankHolidayRunning = record.BankHolidayRunning.ToString(),
                Catering = record.CateringCode.ToString(),
                OperatingCharacteristics = record.OperatingCharacteristics.ToString(),
                PowerType = record.PowerType.ToString(),
                Reservations = record.Reservations.ToString(),
                RunningDays = record.RunningDays.ToString(),
                ScheduleEndDate = record.EndDate,
                Seating = record.SeatingClass.ToString(),
                Sleepers = record.Sleepers.ToString(),
                StpIndicator = record.StpIndicator.ToString(),
                SystemId = record.UniqueId,
                TrainCategory = record.TrainCategory,
                TrainIdentity = record.TrainIdentity,
                TrainServiceCode = record.TrainServiceCode,
                TrainStatus = record.TrainStatus
            };
        }
    }
}