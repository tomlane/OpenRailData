﻿using System;
using System.Globalization;
using Newtonsoft.Json;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.Entities.Enums;
using OpenRailData.TrainMovement.TrainMovementParsing;
using OpenRailData.TrainMovementParsing.Json.RawMessages;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainActivationMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0001";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var deserializedActivation = JsonConvert.DeserializeObject<DeserializedJsonTrainActivation>(message);

            var activation = new TrainActivation
            {
                SourceDeviceId = deserializedActivation.Header.SourceDeviceId,
                OriginalDataSource = deserializedActivation.Header.OriginalDataSource,
                SourceSystemId = deserializedActivation.Header.SourceSystemId,

                ScheduleSource = (ScheduleSource)Enum.Parse(typeof(ScheduleSource), deserializedActivation.Body.ScheduleSource),
                TrainFileAddress = string.Empty,
                ScheduleEndDate = DateTime.ParseExact(deserializedActivation.Body.ScheduleEndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                TrainId = deserializedActivation.Body.TrainId,
                OriginTimestamp = DateTime.ParseExact(deserializedActivation.Body.OriginTimeStamp, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedActivation.Body.CreationTimestamp)).UtcDateTime,
                OriginStanox = deserializedActivation.Body.OriginStanox,
                TrainServiceCode = deserializedActivation.Body.TrainServiceCode,
                TocId = deserializedActivation.Body.TocId,
                DRecordNumber = deserializedActivation.Body.DRecordNumber,
                CallType = (TrainCallType)Enum.Parse(typeof(TrainCallType), deserializedActivation.Body.TrainCallType),
                TrainUid = deserializedActivation.Body.TrainUid,
                CallMode = (TrainCallMode)Enum.Parse(typeof(TrainCallMode), deserializedActivation.Body.TrainCallMode),
                ScheduleType = (ScheduleType)Enum.Parse(typeof(ScheduleType), deserializedActivation.Body.ScheduleType),
                ScheduleOriginStanox = deserializedActivation.Body.ScheduleOriginStanox,
                ScheduleWttId = deserializedActivation.Body.ScheduleWttId,
                ScheduleStartDate = DateTime.ParseExact(deserializedActivation.Body.ScheduleStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            if (!string.IsNullOrWhiteSpace(deserializedActivation.Body.OriginDepartureTimestamp))
                activation.OriginDepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedActivation.Body.OriginDepartureTimestamp)).UtcDateTime;

            if (!string.IsNullOrWhiteSpace(deserializedActivation.Body.TrainFileAddress))
                activation.TrainFileAddress = deserializedActivation.Body.TrainFileAddress;

            // Activation schedule type issue fix.
            switch (activation.ScheduleType)
            {
                case ScheduleType.P:
                    activation.ScheduleType = ScheduleType.O;
                    break;
                case ScheduleType.O:
                    activation.ScheduleType = ScheduleType.P;
                    break;
            }

            return activation;
        }
    }
}