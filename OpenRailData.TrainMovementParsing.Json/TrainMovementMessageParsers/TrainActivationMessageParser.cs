using System;
using System.Globalization;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Domain.TrainMovements.Enums;
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
                TrainFileAddress = deserializedActivation.Body.TrainFileAddress,
                ScheduleEndDate = DateTime.ParseExact(deserializedActivation.Body.ScheduleEndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                TrainId = deserializedActivation.Body.TrainId,
                OriginTimestamp = DateTime.ParseExact(deserializedActivation.Body.OriginTimeStamp, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EventTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedActivation.Body.CreationTimestamp)).DateTime,
                OriginStanox = deserializedActivation.Body.OriginStanox,
                OriginDepartureTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(deserializedActivation.Body.OriginDepartureTimestamp)).DateTime,
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

            return activation;
        }
    }
}