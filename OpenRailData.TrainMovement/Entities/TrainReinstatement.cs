using System;

namespace OpenRailData.TrainMovement.Entities
{
    public class TrainReinstatement : ITrainMovementMessage
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainReinstatement;

        /// <summary>
        ///     Set to the device ID of the terminal that issued the request.
        /// </summary>
        public string SourceDeviceId { get; set; }
        /// <summary>
        ///     Set to "TRUST" for a reinstatement message.
        /// </summary>
        public string SourceSystemId { get; set; }
        /// <summary>
        ///     Set to "TOPS", "SDR" or "TRUST DA".
        /// </summary>
        public string OriginalDataSource { get; set; }
        /// <summary>
        /// 	The 10-character unique identity for this train at TRUST activation time.
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        /// Where a train has had its identity changed, the current 10-character unique identity for this train.
        /// </summary>
        public string CurrentTrainId { get; set; }
        /// <summary>
        /// 	The planned departure time associated with the original location.
        /// </summary>
        public DateTime? OriginalLocationTimestamp { get; set; }
        /// <summary>
        /// 	The planned departure time at the location where the train is being reinstated
        /// </summary>
        public DateTime DepartureTimestamp { get; set; }
        /// <summary>
        /// 	The STANOX of the location at which the train is reinstated.
        /// </summary>
        public string LocationStanox { get; set; }
        /// <summary>
        ///     The STANOX of the location in the schedule at activation time, if the location has been revised.
        /// </summary>
        public string OriginalLocationStanox { get; set; }
        /// <summary>
        ///     The time at which the train was reinstated.
        /// </summary>
        public DateTime EventTimestamp { get; set; }
        /// <summary>
        /// 	Operating company ID as per TOC Codes.
        /// </summary>
        public string TocId { get; set; }
        /// <summary>
        ///     Operating company ID as per TOC Codes
        /// </summary>
        public string DivisionCode { get; set; }
        /// <summary>
        ///     The TOPS train file address, if applicable.
        /// </summary>
        public string TrainFileAddress { get; set; }
        /// <summary>
        /// 	Train service code as per schedule.
        /// </summary>
        public string TrainServiceCode { get; set; }

        public override string ToString()
        {
            return $"CurrentTrainId: {CurrentTrainId}, DepartureTimestamp: {DepartureTimestamp}, DivisionCode: {DivisionCode}, EventTimestamp: {EventTimestamp}, LocationStanox: {LocationStanox}, OriginalDataSource: {OriginalDataSource}, OriginalLocationStanox: {OriginalLocationStanox}, OriginalLocationTimestamp: {OriginalLocationTimestamp}, SourceDeviceId: {SourceDeviceId}, SourceSystemId: {SourceSystemId}, TocId: {TocId}, TrainFileAddress: {TrainFileAddress}, TrainId: {TrainId}, TrainServiceCode: {TrainServiceCode}";
        }

        protected bool Equals(TrainReinstatement other)
        {
            return MessageType == other.MessageType && 
                string.Equals(SourceDeviceId, other.SourceDeviceId) && 
                string.Equals(SourceSystemId, other.SourceSystemId) && 
                string.Equals(OriginalDataSource, other.OriginalDataSource) && 
                string.Equals(TrainId, other.TrainId) && 
                string.Equals(CurrentTrainId, other.CurrentTrainId) && 
                OriginalLocationTimestamp.Equals(other.OriginalLocationTimestamp) && 
                DepartureTimestamp.Equals(other.DepartureTimestamp) && 
                string.Equals(LocationStanox, other.LocationStanox) && 
                string.Equals(OriginalLocationStanox, other.OriginalLocationStanox) && 
                EventTimestamp.Equals(other.EventTimestamp) && 
                string.Equals(TocId, other.TocId) && 
                string.Equals(DivisionCode, other.DivisionCode) && 
                string.Equals(TrainFileAddress, other.TrainFileAddress) && 
                string.Equals(TrainServiceCode, other.TrainServiceCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TrainReinstatement) obj);
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
                hashCode = (hashCode*397) ^ OriginalLocationTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ DepartureTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (LocationStanox != null ? LocationStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OriginalLocationStanox != null ? OriginalLocationStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ EventTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (TocId != null ? TocId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DivisionCode != null ? DivisionCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainFileAddress != null ? TrainFileAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainServiceCode != null ? TrainServiceCode.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}