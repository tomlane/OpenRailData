using System;

namespace OpenRailData.TrainMovement.Entities
{
    public interface ITrainMovementMessage
    {
        TrainMovementMessageType MessageType { get; }
        /// <summary>
        /// Source device id.
        /// </summary>
        string SourceDeviceId { get; set; }
        /// <summary>
        /// Source system id.
        /// </summary>
        string SourceSystemId { get; set; }
        /// <summary>
        /// Original data source.
        /// </summary>
        string OriginalDataSource { get; set; }
        /// <summary>
        /// Train id.
        /// </summary>
        string TrainId { get; set; } 
        /// <summary>
        /// Event timestamp.
        /// </summary>
        DateTime EventTimestamp { get; set; }
        /// <summary>
        /// Train service code.
        /// </summary>
        string TrainServiceCode { get; set; }
    }
}