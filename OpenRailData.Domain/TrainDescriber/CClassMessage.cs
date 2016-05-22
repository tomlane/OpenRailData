using System;

namespace OpenRailData.Domain.TrainDescriber
{
    public class CClassMessage
    {
        /// <summary>
        ///     Message time.
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        ///     Alphanumeric code representing the Train Describer area that the message originates from.
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        ///     Type of message.
        /// </summary>
        public CClassMessageType MessageType { get; set; }
        /// <summary>
        ///     From berth.
        /// </summary>
        public string FromBerth { get; set; }
        /// <summary>
        ///     To berth.
        /// </summary>
        public string ToBerth { get; set; }
        /// <summary>
        ///     Four-letter alphanumeric code representing the headcode or description of the train.
        /// </summary>
        public string TrainDescription { get; set; }
        /// <summary>
        ///     Reporting time.
        /// </summary>
        public DateTime? ReportingTime { get; set; }
    }
}
