using System;
using Newtonsoft.Json;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers
{
    public class BerthCancelMessageParser : ITrainDescriberMessageParser
    {
        public string DescriberMessageType { get; } = "CB_MSG";

        public ITrainDescriberMessage ParseDescriberMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            var jsonClass = JsonConvert.DeserializeObject<DeserializedCClassMessage>(message);

            return new CClassMessage
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(jsonClass.Time)).DateTime,
                AreaId = jsonClass.AreaId,
                MessageType = CClassMessageType.BerthCancel,
                FromBerth = jsonClass.FromBerth,
                TrainDescription = jsonClass.TrainDescription
            };
        }
    }
}