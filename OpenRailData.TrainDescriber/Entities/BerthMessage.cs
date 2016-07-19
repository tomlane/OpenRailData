using System;

namespace OpenRailData.TrainDescriber.Entities
{
    public class BerthMessage : ITrainDescriberMessage
    {
        public TrainDescriberMessageType MessageType { get; } = TrainDescriberMessageType.BerthMessage;

        /// <summary>
        ///     Message time.
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        ///     Alphanumeric code representing the Train Describer area that the message originates from.
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        ///     Type of message.
        /// </summary>
        public BerthMessageType BerthMessageType { get; set; }
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

        protected bool Equals(BerthMessage other)
        {
            return string.Equals(AreaId, other.AreaId) && 
                string.Equals(FromBerth, other.FromBerth) && 
                MessageType == other.MessageType && 
                ReportingTime.Equals(other.ReportingTime) && 
                Timestamp.Equals(other.Timestamp) && 
                string.Equals(ToBerth, other.ToBerth) && 
                string.Equals(TrainDescription, other.TrainDescription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BerthMessage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AreaId != null ? AreaId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FromBerth != null ? FromBerth.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) MessageType;
                hashCode = (hashCode*397) ^ ReportingTime.GetHashCode();
                hashCode = (hashCode*397) ^ Timestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (ToBerth != null ? ToBerth.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainDescription != null ? TrainDescription.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"AreaId: {AreaId}, FromBerth: {FromBerth}, MessageType: {MessageType}, ReportingTime: {ReportingTime}, Timestamp: {Timestamp}, ToBerth: {ToBerth}, TrainDescription: {TrainDescription}";
        }
    }
}
