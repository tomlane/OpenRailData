using System;
using OpenRailData.CommonDatabase;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Entities
{
    public class BerthMessageEntity : IIdentifyable
    {
        public Guid? Id { get; set; }

        public DateTime Timestamp { get; set; }
        public string AreaId { get; set; }
        public BerthMessageType MessageType { get; set; }
        public string FromBerth { get; set; }
        public string ToBerth { get; set; }
        public string TrainDescription { get; set; }
        public DateTime? ReportingTime { get; set; }
    }
}