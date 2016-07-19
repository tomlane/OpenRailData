using System;

namespace OpenRailData.TrainMovement.Entities
{
    public class ChangeOfIdentity : ITrainMovementMessage
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.ChangeOfIdentity;

        /// <summary>
        /// 	Set to the device ID of the terminal that issued the request.
        /// </summary>
        public string SourceDeviceId { get; set; }
        /// <summary>
        /// 	Set to "TRUST" for a change of identity message.
        /// </summary>
        public string SourceSystemId { get; set; }
        /// <summary>
        ///     Set to "TOPS" for an change of identity message.
        /// </summary>
        public string OriginalDataSource { get; set; }
        /// <summary>
        ///     The 10-character unique identity for this train at TRUST activation time.
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        ///     If this is the second or subsequent change of identity for a train, this field will contain the revised_train_id field from the previous change of identity message.
        /// </summary>
        public string CurrentTrainId { get; set; }
        /// <summary>
        /// 	The new 10-character unique identity for this train.
        /// </summary>
        public string RevisedTrainId { get; set; }
        /// <summary>
        /// 	The TOPS train file address, if applicable.
        /// </summary>
        public string TrainFileAddress { get; set; }
        /// <summary>
        ///     Train service code as per schedule.
        /// </summary>
        public string TrainServiceCode { get; set; }
        /// <summary>
        /// 	The time, in milliseconds, when the train's identity was changed.
        /// </summary>
        public DateTime EventTimestamp { get; set; }

        public override string ToString()
        {
            return $"CurrentTrainId: {CurrentTrainId}, EventTimestamp: {EventTimestamp}, OriginalDataSource: {OriginalDataSource}, RevisedTrainId: {RevisedTrainId}, SourceDeviceId: {SourceDeviceId}, SourceSystemId: {SourceSystemId}, TrainFileAddress: {TrainFileAddress}, TrainId: {TrainId}, TrainServiceCode: {TrainServiceCode}";
        }

        protected bool Equals(ChangeOfIdentity other)
        {
            return MessageType == other.MessageType && 
                string.Equals(SourceDeviceId, other.SourceDeviceId) && 
                string.Equals(SourceSystemId, other.SourceSystemId) && 
                string.Equals(OriginalDataSource, other.OriginalDataSource) && 
                string.Equals(TrainId, other.TrainId) && 
                string.Equals(CurrentTrainId, other.CurrentTrainId) && 
                string.Equals(RevisedTrainId, other.RevisedTrainId) && 
                string.Equals(TrainFileAddress, other.TrainFileAddress) && 
                string.Equals(TrainServiceCode, other.TrainServiceCode) && 
                EventTimestamp.Equals(other.EventTimestamp);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeOfIdentity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) MessageType;
                hashCode = (hashCode*397) ^ (SourceDeviceId != null ? SourceDeviceId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SourceSystemId != null ? SourceSystemId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OriginalDataSource != null ? OriginalDataSource.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainId != null ? TrainId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CurrentTrainId != null ? CurrentTrainId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RevisedTrainId != null ? RevisedTrainId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainFileAddress != null ? TrainFileAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainServiceCode != null ? TrainServiceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ EventTimestamp.GetHashCode();
                return hashCode;
            }
        }
    }
}