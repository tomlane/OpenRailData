using System;
using OpenRailData.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Entities
{
    public class ChangeOfIdentityEntity : IIdentifyable
    {
        public Guid? Id { get; set; }

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