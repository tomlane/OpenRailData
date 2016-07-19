using System;
using Newtonsoft.Json;
using OpenRailData.TrainDescriber.Entities;
using OpenRailData.TrainDescriber.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json.RawMessages;

namespace OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers
{
    public class SignallingRefreshMessageParser : ITrainDescriberMessageParser
    {
        public string DescriberMessageType { get; } = "SG_MSG";

        public ITrainDescriberMessage ParseDescriberMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var jsonClass = JsonConvert.DeserializeObject<DeserializedSClassMessage>(message);

            return new SignalMessage
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(jsonClass.Time)).UtcDateTime,
                AreaId = jsonClass.AreaId,
                SignalMessageType = SignalMessageType.Refresh,
                Address = jsonClass.Address,
                Data = jsonClass.Data
            };
        }
    }
}