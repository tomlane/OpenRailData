using System;

namespace OpenRailData.Domain.TrainDescriber
{
    public interface ITrainDescriberMessage
    {
        TrainDescriberMessageType MessageType { get; }

        DateTime Timestamp { get; set; }

        string AreaId { get; set; }
    }

    public enum TrainDescriberMessageType   
    {
        BerthMessage,
        SignalMessage
    }
}