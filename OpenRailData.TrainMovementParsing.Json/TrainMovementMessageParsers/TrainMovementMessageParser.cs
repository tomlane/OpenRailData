using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Domain.TrainMovements.Enums;
using OpenRailData.TrainMovementParsing.Json.RawMessages;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainMovementMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0003";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var deserializedMovement = JsonConvert.DeserializeObject<DeserializedJsonTrainMovement>(message);

            var movement = new TrainMovement
            {
                SourceDeviceId = deserializedMovement.Header.SourceDeviceId,
                OriginalDataSource = deserializedMovement.Header.OriginalDataSource,
                SourceSystemId = deserializedMovement.Header.SourceSystemId,

                EventType = EventType.Arrival, // TODO: use my provider
                PassengerTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedMovement.Body.GbttTimestamp)).DateTime, // TODO: can be empty string
                OriginalLocationStanox = deserializedMovement.Body.OriginalLocationStanox,
                PlannedTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedMovement.Body.PlannedTimestamp)).DateTime,
                TimetableVariation = int.Parse(deserializedMovement.Body.TimetableVariation),
                OriginalLocationTimestamp = null, // TODO: needs investigation
                CurrentTrainId = deserializedMovement.Body.CurrentTrainId,
                IsDelayMonitoringPoint = bool.Parse(deserializedMovement.Body.DelayMonitoringPoint),
                NextReportRunTime = int.Parse(deserializedMovement.Body.NextReportRunTime), // TODO: can be empty
                ReportingStanox = deserializedMovement.Body.ReportingStanox,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedMovement.Body.ActualTimestamp)).DateTime,
                IsCorrection = bool.Parse(deserializedMovement.Body.Correction),
                EventSource = EventSource.Automatic, // TODO: use my provider
                TrainFileAddress = deserializedMovement.Body.TrainFileAddress,
                Platform = deserializedMovement.Body.Platform,
                DivisionCode = deserializedMovement.Body.DivisionCode,
                HasTerminated = bool.Parse(deserializedMovement.Body.TrainTerminated),
                TrainId = deserializedMovement.Body.TrainId,
                IsOffRoute = bool.Parse(deserializedMovement.Body.OffRoute),
                VariationStatus = VariationStatus.OnTime, // TODO: use my provider
                TrainServiceCode = deserializedMovement.Body.TrainServiceCode,
                TocId = deserializedMovement.Body.TocId,
                LocationStanox = deserializedMovement.Body.LocationStanox,
                IsAutoExpected = bool.Parse(deserializedMovement.Body.AutoExpected),
                Direction = Direction.Down, // TODO: use my provider
                Route = deserializedMovement.Body.Route,
                PlannedEventType = EventType.Arrival, // TODO: use my provider
                NextReportStanox = deserializedMovement.Body.NextReportStanox,
                Line = deserializedMovement.Body.Line
            };

            return movement;
        }
    }
}