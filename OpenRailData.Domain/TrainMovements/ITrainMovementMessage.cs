using System;

namespace OpenRailData.Domain.TrainMovements
{
    public interface ITrainMovementMessage
    {
        string SourceDeviceId { get; set; }
        string SourceSystemId { get; set; }
        string OriginalDataSource { get; set; }

        string TrainId { get; set; } 

        DateTime EventTimestamp { get; set; }

        string TrainServiceCode { get; set; }
    }
}