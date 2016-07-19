using System;

namespace OpenRailData.TrainMovement.Entities
{
    public class ChangeOfOrigin : ITrainMovementMessage
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.ChangeOfOrigin;

        /// <summary>
        ///     Set to the ID of the device that issued the change of origin message.
        /// </summary>
        public string SourceDeviceId { get; set; }
        /// <summary>
        ///     Set to "TRUST" for a change of origin message.
        /// </summary>
        public string SourceSystemId { get; set; }
        /// <summary>
        ///     Set to "TRUST DA" or "SDR" for a change of origin message.
        /// </summary>
        public string OriginalDataSource { get; set; }
        /// <summary>
        /// 	The 10-character unique identity for this train at TRUST activation time.
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        ///     The planned departure time at the location where the train is being reinstated.
        /// </summary>
        public DateTime DepartureTimestamp { get; set; }
        /// <summary>
        /// 	The STANOX of the new origin of the train.
        /// </summary>
        public string LocationStanox { get; set; }
        /// <summary>
        /// 	If the location has been revised, e.g. the new origin is 'out of plan' for the train, the STANOX of location in the schedule at activation.
        /// </summary>
        public string OriginalLocationStanox { get; set; }
        /// <summary>
        /// 	The planned departure time associated with the original location.
        /// </summary>
        public DateTime? OriginalLocationTimestamp { get; set; }
        /// <summary>
        ///     Always blank.
        /// </summary>
        public string CurrentTrainId { get; set; }
        /// <summary>
        /// 	Train service code as per schedule.
        /// </summary>
        public string TrainServiceCode { get; set; }
        /// <summary>
        ///     The reason code for the cancellation, taken from the Delay Attribution Guide.
        /// </summary>
        public string ReasonCode { get; set; }
        /// <summary>
        /// 	Operating company ID as per TOC Codes.
        /// </summary>
        public string DivisionCode { get; set; }
        /// <summary>
        /// 	Operating company ID as per TOC Codes.
        /// </summary>
        public string TocId { get; set; }
        /// <summary>
        /// 	The TOPS train file address, if applicable.
        /// </summary>
        public string TrainFileAddress { get; set; }
        /// <summary>
        /// 	The time at which the Change of Origin is entered into TRUST.
        /// </summary>
        public DateTime EventTimestamp { get; set; }

        public override string ToString()
        {
            return $"CurrentTrainId: {CurrentTrainId}, DepartureTimestamp: {DepartureTimestamp}, DivisionCode: {DivisionCode}, EventTimestamp: {EventTimestamp}, LocationStanox: {LocationStanox}, OriginalDataSource: {OriginalDataSource}, OriginalLocationStanox: {OriginalLocationStanox}, OriginalLocationTimestamp: {OriginalLocationTimestamp}, ReasonCode: {ReasonCode}, SourceDeviceId: {SourceDeviceId}, SourceSystemId: {SourceSystemId}, TocId: {TocId}, TrainFileAddress: {TrainFileAddress}, TrainId: {TrainId}, TrainServiceCode: {TrainServiceCode}";
        }

        protected bool Equals(ChangeOfOrigin other)
        {
            return MessageType == other.MessageType && 
                string.Equals(SourceDeviceId, other.SourceDeviceId) && 
                string.Equals(SourceSystemId, other.SourceSystemId) && 
                string.Equals(OriginalDataSource, other.OriginalDataSource) && 
                string.Equals(TrainId, other.TrainId) && 
                DepartureTimestamp.Equals(other.DepartureTimestamp) && 
                string.Equals(LocationStanox, other.LocationStanox) && 
                string.Equals(OriginalLocationStanox, other.OriginalLocationStanox) && 
                OriginalLocationTimestamp.Equals(other.OriginalLocationTimestamp) && 
                string.Equals(CurrentTrainId, other.CurrentTrainId) && 
                string.Equals(TrainServiceCode, other.TrainServiceCode) && 
                string.Equals(ReasonCode, other.ReasonCode) && 
                string.Equals(DivisionCode, other.DivisionCode) && 
                string.Equals(TocId, other.TocId) && 
                string.Equals(TrainFileAddress, other.TrainFileAddress) && 
                EventTimestamp.Equals(other.EventTimestamp);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeOfOrigin) obj);
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
                hashCode = (hashCode*397) ^ DepartureTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (LocationStanox != null ? LocationStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OriginalLocationStanox != null ? OriginalLocationStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ OriginalLocationTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (CurrentTrainId != null ? CurrentTrainId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainServiceCode != null ? TrainServiceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ReasonCode != null ? ReasonCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DivisionCode != null ? DivisionCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TocId != null ? TocId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainFileAddress != null ? TrainFileAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ EventTimestamp.GetHashCode();
                return hashCode;
            }
        }
    }
}