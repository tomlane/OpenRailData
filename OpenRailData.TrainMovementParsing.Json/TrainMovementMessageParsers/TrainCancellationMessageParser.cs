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
                TrainFileAddress = deserializedCancellation.Body.TrainFileAddress,
                TrainServiceCode = deserializedCancellation.Body.TrainServiceCode,
                OriginalLocationStanox = deserializedCancellation.Body.OriginalLocationStanox,
                TocId = deserializedCancellation.Body.TocId,
                DepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedCancellation.Body.DepartureTimestamp)).DateTime,
                DivisionCode = deserializedCancellation.Body.DivisionCode,
                LocationStanox = deserializedCancellation.Body.LocationStanox,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedCancellation.Body.CancellationTimestamp)).DateTime,
                ReasonCode = deserializedCancellation.Body.CancellationReasonCode,
                TrainId = deserializedCancellation.Body.TrainId,
                OriginalLocationTimestamp = null, // TODO: Logic needed here, can be empty string
                CancellationType = CancellationType.AtOrigin // TODO: use my provider
            };

            return cancellation;
        }
    }
}