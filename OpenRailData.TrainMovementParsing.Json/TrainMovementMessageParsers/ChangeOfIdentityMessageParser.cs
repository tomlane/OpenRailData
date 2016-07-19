using System;
using Newtonsoft.Json;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementParsing;
using OpenRailData.TrainMovementParsing.Json.RawMessages;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class ChangeOfIdentityMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0007";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var deserializedChangeOfIdentity = JsonConvert.DeserializeObject<DeserializedChangeOfIdentity>(message);

            var changeOfIdentity = new ChangeOfIdentity
            {
                SourceDeviceId = deserializedChangeOfIdentity.Header.SourceDeviceId,
                OriginalDataSource = deserializedChangeOfIdentity.Header.OriginalDataSource,
                SourceSystemId = deserializedChangeOfIdentity.Header.SourceSystemId,

                CurrentTrainId = deserializedChangeOfIdentity.Body.CurrentTrainId,
                TrainFileAddress = string.Empty,
                TrainServiceCode = deserializedChangeOfIdentity.Body.TrainServiceCode,
                RevisedTrainId = deserializedChangeOfIdentity.Body.RevisedTrainId,
                TrainId = deserializedChangeOfIdentity.Body.TrainId,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedChangeOfIdentity.Body.EventTimestamp)).UtcDateTime
            };

            if (!string.IsNullOrWhiteSpace(deserializedChangeOfIdentity.Body.TrainFileAddress))
                changeOfIdentity.TrainFileAddress = deserializedChangeOfIdentity.Body.TrainFileAddress;

            return changeOfIdentity;
        }
    }
}