using System;
using OpenRailData.TrainMovement.Entities.Enums;

namespace OpenRailData.TrainMovement.Entities
{
    public class TrainMovement : ITrainMovementMessage
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainMovement;

        /// <summary>
        ///     Where the movement is manually entered, set to the ID of the device that generated the movement message.
        /// </summary>
        public string SourceDeviceId { get; set; }
        /// <summary>
        ///     Set to "TRUST" for a movement message.
        /// </summary>
        public string SourceSystemId { get; set; }
        /// <summary>
        ///     Set to "TRUST", "TRUST DA", "SDR" or "GPS" for a movement message.
        /// </summary>
        public string OriginalDataSource { get; set; }
        /// <summary>
        ///     The 10-character unique identity for this train at TRUST activation time.
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        /// 	The date and time that this event happened at the location.
        /// </summary>
        public DateTime EventTimestamp { get; set; }
        /// <summary>
        /// 	The STANOX of the location at which this event happened.
        /// </summary>
        public string LocationStanox { get; set; }
        /// <summary>
        ///     The planned GBTT (passenger) date and time that the event was due to happen at this location.
        /// </summary>
        public DateTime? PassengerTimestamp { get; set; }
        /// <summary>
        ///     The planned date and time that this event was due to happen at this location.
        /// </summary>
        public DateTime? PlannedTimestamp { get; set; }
        /// <summary>
        /// 	If the location has been revised, the STANOX of the location in the schedule at activation time.
        /// </summary>
        public string OriginalLocationStanox { get; set; }
        /// <summary>
        /// 	The planned departure time associated with the original location.
        /// </summary>
        public DateTime? OriginalLocationTimestamp { get; set; }
        /// <summary>
        /// 	The planned type of event - one of "ARRIVAL", "DEPARTURE" or "DESTINATION".
        /// </summary>
        public EventType PlannedEventType { get; set; }
        /// <summary>
        ///     The type of event - either "ARRIVAL" or "DEPARTURE".
        /// </summary>
        public EventType EventType { get; set; }
        /// <summary>
        /// 	Whether the event source was "AUTOMATIC" from SMART, or "MANUAL" from TOPS or TRUST SDR.
        /// </summary>
        public EventSource EventSource { get; set; }
        /// <summary>
        /// 	Set to "false" if this report is not a correction of a previous report, or "true" if it is.
        /// </summary>
        public bool Correction { get; set; }
        /// <summary>
        /// 	Set to "false" if this report is for a location in the schedule, or "true" if it is not.
        /// </summary>
        public bool OffRoute { get; set; }
        /// <summary>
        /// 	For automatic reports, either "UP" or "DOWN" depending on the direction of travel. Set to None for arrivals/terminations.
        /// </summary>
        public Direction Direction { get; set; }
        /// <summary>
        /// 	A single character (or blank) depending on the line the train is travelling on, e.g. F = Fast, S = Slow.
        /// </summary>
        public string Line { get; set; }
        /// <summary>
        /// 	Two characters (including a space for a single character) or blank if the movement report is associated with a platform number.
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        ///     A single character (or blank) to indicate the exit route from this location.
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        /// 	Where a train has had its identity changed, the current 10-character unique identity for this train.
        /// </summary>
        public string CurrentTrainId { get; set; }
        /// <summary>
        ///     Train service code as per schedule.
        /// </summary>
        public string TrainServiceCode { get; set; }
        /// <summary>
        ///     Operating company ID as per TOC Codes.
        /// </summary>
        public string DivisionCode { get; set; }
        /// <summary>
        ///     Operating company ID as per TOC Codes.
        /// </summary>
        public string TocId { get; set; }
        /// <summary>
        /// 	The number of minutes variation from the scheduled time at this location.
        /// </summary>
        /// <remarks>Off-route reports will contain "0".</remarks>
        public int TimetableVariation { get; set; }
        /// <summary>
        /// 	One of "ON TIME", "EARLY", "LATE" or "OFF ROUTE".
        /// </summary>
        public VariationStatus VariationStatus { get; set; }
        /// <summary>
        /// 	The STANOX of the location at which the next report for this train is due.
        /// </summary>
        public string NextReportStanox { get; set; }
        /// <summary>
        ///     The running time to the next location.
        /// </summary>
        public int NextReportRunTime { get; set; }
        /// <summary>
        /// 	Set to "true" if the train has completed its journey, or "false" otherwise.
        /// </summary>
        public bool Terminated { get; set; }
        /// <summary>
        /// 	Set to "true" if this is a delay monitoring point, "false" if it is not.
        /// </summary>
        /// <remarks>Off-route reports will contain "false".</remarks>
        public bool DelayMonitoringPoint { get; set; }
        /// <summary>
        /// 	The TOPS train file address, if applicable.
        /// </summary>
        public string TrainFileAddress { get; set; }
        /// <summary>
        ///     The STANOX of the location that generated this report.
        /// </summary>
        /// <remarks>Set to "00000" for manual and off-route reports.</remarks>
        public string ReportingStanox { get; set; }
        /// <summary>
        ///     Set to "true" if an automatic report is expected for this location, otherwise "false".
        /// </summary>
        public bool AutoExpected { get; set; }

        public override string ToString()
        {
            return $"CurrentTrainId: {CurrentTrainId}, Direction: {Direction}, DivisionCode: {DivisionCode}, EventSource: {EventSource}, EventTimestamp: {EventTimestamp}, EventType: {EventType}, HasTerminated: {Terminated}, IsAutoExpected: {AutoExpected}, IsCorrection: {Correction}, IsDelayMonitoringPoint: {DelayMonitoringPoint}, IsOffRoute: {OffRoute}, Line: {Line}, LocationStanox: {LocationStanox}, NextReportRunTime: {NextReportRunTime}, NextReportStanox: {NextReportStanox}, OriginalDataSource: {OriginalDataSource}, OriginalLocationStanox: {OriginalLocationStanox}, OriginalLocationTimestamp: {OriginalLocationTimestamp}, PassengerTimestamp: {PassengerTimestamp}, PlannedEventType: {PlannedEventType}, PlannedTimestamp: {PlannedTimestamp}, Platform: {Platform}, ReportingStanox: {ReportingStanox}, Route: {Route}, SourceDeviceId: {SourceDeviceId}, SourceSystemId: {SourceSystemId}, TimetableVariation: {TimetableVariation}, TocId: {TocId}, TrainFileAddress: {TrainFileAddress}, TrainId: {TrainId}, TrainServiceCode: {TrainServiceCode}, VariationStatus: {VariationStatus}";
        }

        protected bool Equals(TrainMovement other)
        {
            return MessageType == other.MessageType && 
                string.Equals(SourceDeviceId, other.SourceDeviceId) && 
                string.Equals(SourceSystemId, other.SourceSystemId) && 
                string.Equals(OriginalDataSource, other.OriginalDataSource) && 
                string.Equals(TrainId, other.TrainId) && 
                EventTimestamp.Equals(other.EventTimestamp) && 
                string.Equals(LocationStanox, other.LocationStanox) && 
                PassengerTimestamp.Equals(other.PassengerTimestamp) && 
                PlannedTimestamp.Equals(other.PlannedTimestamp) && 
                string.Equals(OriginalLocationStanox, other.OriginalLocationStanox) && 
                OriginalLocationTimestamp.Equals(other.OriginalLocationTimestamp) && 
                PlannedEventType == other.PlannedEventType && 
                EventType == other.EventType && 
                EventSource == other.EventSource && 
                Correction == other.Correction && 
                OffRoute == other.OffRoute && 
                Direction == other.Direction && 
                string.Equals(Line, other.Line) && 
                string.Equals(Platform, other.Platform) && 
                string.Equals(Route, other.Route) && 
                string.Equals(CurrentTrainId, other.CurrentTrainId) && 
                string.Equals(TrainServiceCode, other.TrainServiceCode) && 
                string.Equals(DivisionCode, other.DivisionCode) && 
                string.Equals(TocId, other.TocId) && 
                TimetableVariation == other.TimetableVariation && 
                VariationStatus == other.VariationStatus && 
                string.Equals(NextReportStanox, other.NextReportStanox) && 
                NextReportRunTime == other.NextReportRunTime && 
                Terminated == other.Terminated && 
                DelayMonitoringPoint == other.DelayMonitoringPoint && 
                string.Equals(TrainFileAddress, other.TrainFileAddress) && 
                string.Equals(ReportingStanox, other.ReportingStanox) && 
                AutoExpected == other.AutoExpected;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TrainMovement) obj);
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
                hashCode = (hashCode*397) ^ EventTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (LocationStanox != null ? LocationStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PassengerTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ PlannedTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (OriginalLocationStanox != null ? OriginalLocationStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ OriginalLocationTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (int) PlannedEventType;
                hashCode = (hashCode*397) ^ (int) EventType;
                hashCode = (hashCode*397) ^ (int) EventSource;
                hashCode = (hashCode*397) ^ Correction.GetHashCode();
                hashCode = (hashCode*397) ^ OffRoute.GetHashCode();
                hashCode = (hashCode*397) ^ Direction.GetHashCode();
                hashCode = (hashCode*397) ^ (Line != null ? Line.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Platform != null ? Platform.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Route != null ? Route.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CurrentTrainId != null ? CurrentTrainId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainServiceCode != null ? TrainServiceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DivisionCode != null ? DivisionCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TocId != null ? TocId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ TimetableVariation;
                hashCode = (hashCode*397) ^ (int) VariationStatus;
                hashCode = (hashCode*397) ^ (NextReportStanox != null ? NextReportStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ NextReportRunTime;
                hashCode = (hashCode*397) ^ Terminated.GetHashCode();
                hashCode = (hashCode*397) ^ DelayMonitoringPoint.GetHashCode();
                hashCode = (hashCode*397) ^ (TrainFileAddress != null ? TrainFileAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ReportingStanox != null ? ReportingStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ AutoExpected.GetHashCode();
                return hashCode;
            }
        }
    }
}
