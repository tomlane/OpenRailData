using System;

namespace OpenRailData.Domain.TrainDescriber
{
    public interface ITrainDescriberMessage
    {
        DateTime Timestamp { get; set; }

        string AreaId { get; set; }
    }
}