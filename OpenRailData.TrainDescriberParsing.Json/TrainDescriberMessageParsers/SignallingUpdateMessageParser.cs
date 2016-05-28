using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.TrainDescriberParsing.Json.RawMessages;

namespace OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers
{
    public class SignallingUpdateMessageParser : ITrainDescriberMessageParser
    {
        public string DescriberMessageType { get; } = "SF_MSG";

        public ITrainDescriberMessage ParseDescriberMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var jsonClass = JsonConvert.DeserializeObject<DeserializedSClassMessage>(message);

            return new SignalMessage
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(jsonClass.Time)).DateTime,
                AreaId = jsonClass.AreaId,
                SignalMessageType = SignalMessageType.Update,
                Address = jsonClass.Address,
                Data = jsonClass.Data
            };
        }
    }
}