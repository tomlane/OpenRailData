using System;
using OpenRailData.Domain.TrainMovements.Enums;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Entites
{
    public class TrainCancellationEntity : IIdentifyable
    {
        public Guid? Id { get; set; }

        public string SourceDeviceId { get; set; }
        public string SourceSystemId { get; set; }
        public string OriginalDataSource { get; set; }
        public string TrainId { get; set; }
        public string OriginalLocationStanox { get; set; }
        public DateTime? OriginalLocationTimestamp { get; set; }
        public string TocId { get; set; }
        public DateTime DepartureTimestamp { get; set; }
        public string DivisionCode { get; set; }
        public string LocationStanox { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string ReasonCode { get; set; }
        public CancellationType CancellationType { get; set; }
        public string TrainServiceCode { get; set; }
        public string TrainFileAddress { get; set; }
    }
}