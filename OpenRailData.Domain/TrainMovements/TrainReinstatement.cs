using System;

namespace OpenRailData.Domain.TrainMovements
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
    }
}