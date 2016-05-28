using System;
using OpenRailData.Domain.TrainMovements.Enums;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Entites
{
    public class TrainActivationEntity : IIdentifyable
    {
        public Guid? Id { get; set; }

        public string SourceDeviceId { get; set; }
        public string SourceSystemId { get; set; }
        public string OriginalDataSource { get; set; }
        public string TrainId { get; set; }
        public DateTime EventTimestamp { get; set; }
        public DateTime OriginTimestamp { get; set; }
        public string TrainUid { get; set; }
        public string ScheduleOriginStanox { get; set; }
        public DateTime ScheduleStartDate { get; set; }
        public DateTime ScheduleEndDate { get; set; }
        public ScheduleSource ScheduleSource { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public string ScheduleWttId { get; set; }
        public string DRecordNumber { get; set; }
        public string OriginStanox { get; set; }
        public DateTime OriginDepartureTimestamp { get; set; }
        public TrainCallType CallType { get; set; }
        public TrainCallMode CallMode { get; set; }
        public string TocId { get; set; }
        public string TrainServiceCode { get; set; }
        public string TrainFileAddress { get; set; }
    }
}