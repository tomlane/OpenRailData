using System;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Entities
{
    public class BerthMessageEntity : IIdentifyable
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }
        public string AreaId { get; set; }
        public CClassMessageType MessageType { get; set; }
        public string FromBerth { get; set; }
        public string ToBerth { get; set; }
        public string TrainDescription { get; set; }
        public DateTime? ReportingTime { get; set; }
    }
}