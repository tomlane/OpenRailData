using System;
using OpenRailData.Domain.TrainMovements.Enums;

namespace OpenRailData.Domain.TrainMovements
{
    public class TrainCancellation : ITrainMovementMessage
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainCancellation;

        /// <summary>
        ///     Set to the device ID of the terminal that issued the request.
        /// </summary>
        public string SourceDeviceId { get; set; }
        /// <summary>
        /// 	Set to "TRUST" for a cancellation message.
        /// </summary>
        public string SourceSystemId { get; set; }
        /// <summary>
        ///     Set to "TOPS" or "SDR" for a reactionary cancellation, or "" for a planned cancellation (STP 'C').
        /// </summary>
        public string OriginalDataSource { get; set; }
        /// <summary>
        ///     The 10-character unique identity for this train (sent in the TRUST activation message).
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        /// 	For an an "OUT OF PLAN" cancellation, this is the location that the train should have been at according to the schedule.
        /// </summary>
        public string OriginalLocationStanox { get; set; }
        /// <summary>
        ///     For an "OUT OF PLAN" cancellation, this is the departure time of the location that the train should have been at according to the schedule.
        /// </summary>
        public DateTime? OriginalLocationTimestamp { get; set; }
        /// <summary>
        /// 	Operating company ID as per TOC Codes.
        /// </summary>
        public string TocId { get; set; }
        /// <summary>
        ///     The departure time at the location that the train is cancelled from (in milliseconds since the UNIX epoch).
        /// </summary>
        public DateTime DepartureTimestamp { get; set; }
        /// <summary>
        ///     Operating company ID as per TOC Codes.
        /// </summary>
        public string DivisionCode { get; set; }
        /// <summary>
        ///     The STANOX of the location that the train is being cancelled from. 
        /// </summary>
        /// <remarks>For an "OUT OF PLAN" cancellation, this STANOX will not be in the schedule, but a Train Movement message will have already been sent.</remarks>
        public string LocationStanox { get; set; }
        /// <summary>
        ///     The time at which the cancellation was input to TRUST.
        /// </summary>
        public DateTime EventTimestamp { get; set; }
        /// <summary>
        /// 	The reason code for the cancellation, taken from the Delay Attribution Guide.
        /// </summary>
        public string ReasonCode { get; set; }
        /// <summary>
        /// 	Either "ON CALL" for a planned cancellation, "AT ORIGIN", "EN ROUTE" or "OUT OF PLAN".
        /// </summary>
        public CancellationType CancellationType { get; set; }
        /// <summary>
        /// 	Train service code as per the schedule.
        /// </summary>
        public string TrainServiceCode { get; set; }
        /// <summary>
        /// 	The TOPS train file address, if applicable.
        /// </summary>
        public string TrainFileAddress { get; set; }

        public override string ToString()
        {
            return $"CancellationType: {CancellationType}, DepartureTimestamp: {DepartureTimestamp}, DivisionCode: {DivisionCode}, EventTimestamp: {EventTimestamp}, LocationStanox: {LocationStanox}, OriginalDataSource: {OriginalDataSource}, OriginalLocationStanox: {OriginalLocationStanox}, OriginalLocationTimestamp: {OriginalLocationTimestamp}, ReasonCode: {ReasonCode}, SourceDeviceId: {SourceDeviceId}, SourceSystemId: {SourceSystemId}, TocId: {TocId}, TrainFileAddress: {TrainFileAddress}, TrainId: {TrainId}, TrainServiceCode: {TrainServiceCode}";
        }
    }
}
