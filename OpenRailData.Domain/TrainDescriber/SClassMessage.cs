using System;

namespace OpenRailData.Domain.TrainDescriber
{
    public class SClassMessage : ITrainDescriberMessage
    {
        /// <summary>
        ///     Message time.
        /// </summary>
        public DateTime Timestamp { get; set; }
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

        protected bool Equals(SClassMessage other)
        {
            return string.Equals(Address, other.Address) && 
                string.Equals(AreaId, other.AreaId) && 
                string.Equals(Data, other.Data) && 
                MessageType == other.MessageType && 
                Timestamp.Equals(other.Timestamp);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SClassMessage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AreaId != null ? AreaId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Data != null ? Data.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) MessageType;
                hashCode = (hashCode*397) ^ Timestamp.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Address: {Address}, AreaId: {AreaId}, Data: {Data}, MessageType: {MessageType}, Timestamp: {Timestamp}";
        }
    }
}
