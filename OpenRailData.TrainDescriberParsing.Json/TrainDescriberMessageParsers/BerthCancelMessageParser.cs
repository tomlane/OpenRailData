using System;
using Newtonsoft.Json;
using OpenRailData.TrainDescriber.Entities;
using OpenRailData.TrainDescriber.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json.RawMessages;

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

            return new BerthMessage
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(jsonClass.Time)).UtcDateTime,
                AreaId = jsonClass.AreaId,
                BerthMessageType = BerthMessageType.BerthCancel,
                FromBerth = jsonClass.FromBerth,
                TrainDescription = jsonClass.TrainDescription
            };
        }
    }
}