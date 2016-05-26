using System;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Entites
{
    public class ChangeOfIdentityEntity : IIdentifyable
    {
        public int Id { get; set; }

        public string SourceDeviceId { get; set; }
        public string SourceSystemId { get; set; }
        public string OriginalDataSource { get; set; }
        public string TrainId { get; set; }
        public string CurrentTrainId { get; set; }
        public string RevisedTrainId { get; set; }
        public string TrainFileAddress { get; set; }
        public string TrainServiceCode { get; set; }
        public DateTime EventTimestamp { get; set; }
    }
}