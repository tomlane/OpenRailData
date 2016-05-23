using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json
{
    public class TrainMovementMessageParsingService : ITrainMovementMessageParsingService
    {
        private readonly Dictionary<string, ITrainMovementMessageParser> _messageParsers;

        public TrainMovementMessageParsingService(ITrainMovementMessageParser[] messageParsers)
        {
            if (messageParsers == null)
                throw new ArgumentNullException(nameof(messageParsers));

            _messageParsers = messageParsers.ToDictionary(x => x.TrainMovementMessageType, x => x);
        }

        public IEnumerable<ITrainMovementMessage> ParseTrainMovementMessages(IEnumerable<string> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            var response = new List<ITrainMovementMessage>();

            foreach (var message in messages)
            {
                var key = JObject.Parse(message)["header"]["msg_type"].ToString();

                response.Add(_messageParsers[key].ParseMovementMessage(message));
            }

            return response;
        }
    }
}