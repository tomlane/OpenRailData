using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementParsing.Json.RawMessages;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainReinstatementMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0005";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var deserializedTrainReinstatement = JsonConvert.DeserializeObject<DeserializedTrainReinstatement>(message);

            var trainReinstatement = new TrainReinstatement
            {
                SourceDeviceId = deserializedTrainReinstatement.Header.SourceDeviceId,
                OriginalDataSource = deserializedTrainReinstatement.Header.OriginalDataSource,
                SourceSystemId = deserializedTrainReinstatement.Header.SourceSystemId,

                CurrentTrainId = deserializedTrainReinstatement.Body.CurrentTrainId,
                OriginalLocationTimestamp = null,
                TrainFileAddress = deserializedTrainReinstatement.Body.TrainFileAddress,
                TrainServiceCode = deserializedTrainReinstatement.Body.TrainServiceCode,
                TocId = deserializedTrainReinstatement.Body.TocId,
                DivisionCode = deserializedTrainReinstatement.Body.DivisionCode,
                LocationStanox = deserializedTrainReinstatement.Body.LocationStanox,
                TrainId = deserializedTrainReinstatement.Body.TrainId,
                OriginalLocationStanox = deserializedTrainReinstatement.Body.OriginalLocationStanox,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedTrainReinstatement.Body.ReinstatementTimestamp)).DateTime
            };

            if (!string.IsNullOrWhiteSpace(deserializedTrainReinstatement.Body.DepartureTimestamp))
                trainReinstatement.DepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedTrainReinstatement.Body.DepartureTimestamp)).DateTime;

            return trainReinstatement;
        }
    }
}