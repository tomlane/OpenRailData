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

                EventType = (EventType)Enum.Parse(typeof(EventType), deserializedMovement.Body.EventType),
                OriginalLocationStanox = deserializedMovement.Body.OriginalLocationStanox,
                TimetableVariation = int.Parse(deserializedMovement.Body.TimetableVariation),
                OriginalLocationTimestamp = null, // TODO: needs investigation
                CurrentTrainId = deserializedMovement.Body.CurrentTrainId,
                IsDelayMonitoringPoint = bool.Parse(deserializedMovement.Body.DelayMonitoringPoint),
                ReportingStanox = deserializedMovement.Body.ReportingStanox,
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedMovement.Body.ActualTimestamp)).DateTime,
                IsCorrection = bool.Parse(deserializedMovement.Body.Correction),
                EventSource = (EventSource)Enum.Parse(typeof(EventSource), deserializedMovement.Body.EventSource),
                TrainFileAddress = deserializedMovement.Body.TrainFileAddress,
                Platform = deserializedMovement.Body.Platform,
                DivisionCode = deserializedMovement.Body.DivisionCode,
                HasTerminated = bool.Parse(deserializedMovement.Body.TrainTerminated),
                TrainId = deserializedMovement.Body.TrainId,
                IsOffRoute = bool.Parse(deserializedMovement.Body.OffRoute),
                VariationStatus = (VariationStatus)Enum.Parse(typeof(VariationStatus), deserializedMovement.Body.VariationStatus.Replace(" ", String.Empty)),
                TrainServiceCode = deserializedMovement.Body.TrainServiceCode,
                TocId = deserializedMovement.Body.TocId,
                LocationStanox = deserializedMovement.Body.LocationStanox,
                Route = deserializedMovement.Body.Route,
                PlannedEventType = (EventType)Enum.Parse(typeof(EventType), deserializedMovement.Body.PlannedEventType),
                NextReportStanox = deserializedMovement.Body.NextReportStanox,
                Line = deserializedMovement.Body.Line
            };

            if (!string.IsNullOrWhiteSpace(deserializedMovement.Body.PlannedTimestamp))
                movement.PlannedTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedMovement.Body.PlannedTimestamp)).DateTime;

            if (!string.IsNullOrWhiteSpace(deserializedMovement.Body.GbttTimestamp))
                movement.PassengerTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedMovement.Body.GbttTimestamp)).DateTime;

            if (!string.IsNullOrWhiteSpace(deserializedMovement.Body.NextReportRunTime))
                movement.NextReportRunTime = int.Parse(deserializedMovement.Body.NextReportRunTime);

            if (!string.IsNullOrWhiteSpace(deserializedMovement.Body.AutoExpected))
                movement.IsAutoExpected = bool.Parse(deserializedMovement.Body.AutoExpected);

            if (!string.IsNullOrWhiteSpace(deserializedMovement.Body.Direction))
                movement.Direction = (Direction) Enum.Parse(typeof(Direction), deserializedMovement.Body.Direction);

            return movement;
        }
    }
}