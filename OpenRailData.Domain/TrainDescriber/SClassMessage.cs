using System;

namespace OpenRailData.Domain.TrainDescriber
{
    public class SClassMessage
    {
        /// <summary>
        ///     Message time.
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// 	Alphanumeric code representing the Train Describer area that the message originates from.
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        ///     Type of message.
        /// </summary>
        public SClassMessageType MessageType { get; set; }
        /// <summary>
        /// 	Address of the signalling data being updated.
        /// </summary>
        /// <remarks>For an SF_MSG, this is the individual signalling element. For an SG_MSG or SH_MSG, this is the starting address for the four bytes supplied in the data field.</remarks>
        public string Address { get; set; }
        /// <summary>
        /// 	Signalling data.
        /// </summary>
        public string Data { get; set; }
    }
}
