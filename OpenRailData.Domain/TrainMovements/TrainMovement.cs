using System;
using OpenRailData.Domain.TrainMovements.Enums;

namespace OpenRailData.Domain.TrainMovements
{
    public class TrainMovement : ITrainMovementMessage
    {
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
        public DateTime PassengerTimestamp { get; set; }
        /// <summary>
        ///     The planned date and time that this event was due to happen at this location.
        /// </summary>
        public DateTime PlannedTimestamp { get; set; }
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
        public bool IsCorrection { get; set; }
        /// <summary>
        /// 	Set to "false" if this report is for a location in the schedule, or "true" if it is not.
        /// </summary>
        public bool IsOffRoute { get; set; }
        /// <summary>
        /// 	For automatic reports, either "UP" or "DOWN" depending on the direction of travel.
        /// </summary>
        public Direction? Direction { get; set; }
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
        public bool HasTerminated { get; set; }
        /// <summary>
        /// 	Set to "true" if this is a delay monitoring point, "false" if it is not.
        /// </summary>
        /// <remarks>Off-route reports will contain "false".</remarks>
        public bool IsDelayMonitoringPoint { get; set; }
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
        public bool IsAutoExpected { get; set; }
    }
}
