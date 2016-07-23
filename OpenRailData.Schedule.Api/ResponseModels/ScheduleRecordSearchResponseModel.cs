using System;

namespace OpenRailData.Schedule.Api.ResponseModels
{
    public class ScheduleRecordSearchResponseModel
    {
        public string TrainUid { get; set; }
        public string SystemId { get; set; }
        public DateTime ScheduleStartDate { get; set; }
        public DateTime? ScheduleEndDate { get; set; }
        public string RunningDays { get; set; }
        public string BankHolidayRunning { get; set; }
        public string TrainStatus { get; set; }
        public string TrainCategory { get; set; }
        public string TrainIdentity { get; set; }
        public string TrainServiceCode { get; set; }
        public string PowerType { get; set; }
        public string OperatingCharacteristics { get; set; }
        public string Seating { get; set; }
        public string Sleepers { get; set; }
        public string Reservations { get; set; }
        public string Catering { get; set; }
        public string StpIndicator { get; set; }
    }
}