﻿using System;
using Newtonsoft.Json;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementParsing;
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

                CurrentTrainId = string.Empty,
                OriginalLocationTimestamp = null,
                TrainFileAddress = string.Empty,
                TrainServiceCode = deserializedTrainReinstatement.Body.TrainServiceCode,
                TocId = deserializedTrainReinstatement.Body.TocId,
                DivisionCode = deserializedTrainReinstatement.Body.DivisionCode,
                LocationStanox = deserializedTrainReinstatement.Body.LocationStanox,
                TrainId = deserializedTrainReinstatement.Body.TrainId,
                OriginalLocationStanox = deserializedTrainReinstatement.Body.OriginalLocationStanox,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedTrainReinstatement.Body.ReinstatementTimestamp)).UtcDateTime
            };

            if (!string.IsNullOrWhiteSpace(deserializedTrainReinstatement.Body.DepartureTimestamp))
                trainReinstatement.DepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedTrainReinstatement.Body.DepartureTimestamp)).UtcDateTime;

            if (!string.IsNullOrWhiteSpace(deserializedTrainReinstatement.Body.TrainFileAddress))
                trainReinstatement.TrainFileAddress = deserializedTrainReinstatement.Body.TrainFileAddress;

            if (!string.IsNullOrWhiteSpace(deserializedTrainReinstatement.Body.CurrentTrainId))
                trainReinstatement.CurrentTrainId = deserializedTrainReinstatement.Body.CurrentTrainId;

            return trainReinstatement;
        }
    }
}