using System;

namespace OpenRailData.TrainDescriber.Entities
{
    public interface ITrainDescriberMessage
    {
        /// <summary>
        /// Train describer message type.
        /// </summary>
        TrainDescriberMessageType MessageType { get; }
        /// <summary>
        /// Message timestamp.
        /// </summary>
        DateTime Timestamp { get; set; }
        /// <summary>
        /// Describer area id.
        /// </summary>
        string AreaId { get; set; }
    }
}