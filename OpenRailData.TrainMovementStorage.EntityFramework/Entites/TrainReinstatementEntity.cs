using System;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Entites
{
    public class TrainReinstatementEntity : IIdentifyable
    {
        public Guid? Id { get; set; }

        public string SourceDeviceId { get; set; }
        public string SourceSystemId { get; set; }
        public string OriginalDataSource { get; set; }
        public string TrainId { get; set; }
        public string CurrentTrainId { get; set; }
        public DateTime? OriginalLocationTimestamp { get; set; }
        public DateTime? DepartureTimestamp { get; set; }
        public string LocationStanox { get; set; }
        public string OriginalLocationStanox { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string TocId { get; set; }
        public string DivisionCode { get; set; }
        public string TrainFileAddress { get; set; }
        public string TrainServiceCode { get; set; }
    }
}