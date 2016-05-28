using System;

namespace OpenRailData.Domain.TrainMovements
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
    }
}