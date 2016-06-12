using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Domain.TrainMovements.Enums;
using OpenRailData.TrainMovementParsing.Json.RawMessages;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainCancellationMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0002";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var deserializedCancellation = JsonConvert.DeserializeObject<DeserializedJsonTrainCancellation>(message);
            
            var cancellation = new TrainCancellation
            {
                SourceDeviceId = deserializedCancellation.Header.SourceDeviceId,
                OriginalDataSource = deserializedCancellation.Header.OriginalDataSource,
                SourceSystemId = deserializedCancellation.Header.SourceSystemId,
                TrainFileAddress = string.Empty,
                TrainServiceCode = deserializedCancellation.Body.TrainServiceCode,
                OriginalLocationStanox = deserializedCancellation.Body.OriginalLocationStanox,
                TocId = deserializedCancellation.Body.TocId,
                DivisionCode = deserializedCancellation.Body.DivisionCode,
                LocationStanox = deserializedCancellation.Body.LocationStanox,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedCancellation.Body.CancellationTimestamp)).UtcDateTime,
                ReasonCode = deserializedCancellation.Body.CancellationReasonCode,
                TrainId = deserializedCancellation.Body.TrainId,
                CancellationType = (CancellationType)Enum.Parse(typeof(CancellationType), deserializedCancellation.Body.CancellationType.Replace(" ", string.Empty))
            };

            if (!string.IsNullOrWhiteSpace(deserializedCancellation.Body.OriginalLocationTimestamp))
                cancellation.OriginalLocationTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedCancellation.Body.OriginalLocationTimestamp)).UtcDateTime;

            if (!string.IsNullOrWhiteSpace(deserializedCancellation.Body.DepartureTimestamp))
                cancellation.DepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedCancellation.Body.DepartureTimestamp)).UtcDateTime;

            if (!string.IsNullOrWhiteSpace(deserializedCancellation.Body.TrainFileAddress))
                cancellation.TrainFileAddress = deserializedCancellation.Body.TrainFileAddress;

            return cancellation;
        }
    }
}