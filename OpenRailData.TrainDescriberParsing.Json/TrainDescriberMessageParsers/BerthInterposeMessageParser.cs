using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.TrainDescriberParsing.Json.RawMessages;

namespace OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers
{
    public class BerthInterposeMessageParser : ITrainDescriberMessageParser
    {
        public string DescriberMessageType { get; } = "CC_MSG";

        public ITrainDescriberMessage ParseDescriberMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var jsonClass = JsonConvert.DeserializeObject<DeserializedCClassMessage>(message);

            return new BerthMessage
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(jsonClass.Time)).DateTime,
                AreaId = jsonClass.AreaId,
                MessageType = CClassMessageType.BerthInterpose,
                ToBerth = jsonClass.ToBerth,
                TrainDescription = jsonClass.TrainDescription
            };
        }
    }
}