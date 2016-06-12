using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementParsing.Json.RawMessages;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class ChangeOfOriginMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0006";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var deserializedChangeOfOrigin = JsonConvert.DeserializeObject<DeserializedChangeOfOrigin>(message);

            var changeOfOrigin = new ChangeOfOrigin
            {
                SourceDeviceId = deserializedChangeOfOrigin.Header.SourceDeviceId,
                OriginalDataSource = deserializedChangeOfOrigin.Header.OriginalDataSource,
                SourceSystemId = deserializedChangeOfOrigin.Header.SourceSystemId,

                ReasonCode = deserializedChangeOfOrigin.Body.ReasonCode,
                CurrentTrainId = deserializedChangeOfOrigin.Body.CurrentTrainId,
                OriginalLocationTimestamp = null,
                TrainFileAddress = string.Empty,
                TrainServiceCode = deserializedChangeOfOrigin.Body.TrainServiceCode,
                TocId = deserializedChangeOfOrigin.Body.TocId,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedChangeOfOrigin.Body.ChangeOfOriginTimestamp)).DateTime,
                DivisionCode = deserializedChangeOfOrigin.Body.DivisionCode,
                LocationStanox = deserializedChangeOfOrigin.Body.LocationStanox,
                TrainId = deserializedChangeOfOrigin.Body.TrainId,
                OriginalLocationStanox = deserializedChangeOfOrigin.Body.OriginalLocationStanox
            };

            if (!string.IsNullOrWhiteSpace(deserializedChangeOfOrigin.Body.DepartureTimestamp))
                changeOfOrigin.DepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedChangeOfOrigin.Body.DepartureTimestamp)).DateTime;

            if (!string.IsNullOrWhiteSpace(deserializedChangeOfOrigin.Body.TrainFileAddress))
                changeOfOrigin.TrainFileAddress = deserializedChangeOfOrigin.Body.TrainFileAddress;

            return changeOfOrigin;
        }
    }
}