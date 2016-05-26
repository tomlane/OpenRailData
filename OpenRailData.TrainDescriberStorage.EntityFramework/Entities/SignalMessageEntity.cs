﻿using System;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Entities
{
    public class SignalMessageEntity : IIdentifyable
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }
        public string AreaId { get; set; }
        public SClassMessageType MessageType { get; set; }
        public string Address { get; set; }
        public string Data { get; set; }
    }
}