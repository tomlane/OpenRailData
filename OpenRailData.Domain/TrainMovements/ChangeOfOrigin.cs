using System;

namespace OpenRailData.Domain.TrainMovements
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
    }
}