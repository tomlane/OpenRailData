using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementParsing;

namespace OpenRailData.TrainMovementParsing.Json
{
    public class TrainMovementParsingService : ITrainMovementParsingService
    {
        private readonly Dictionary<string, ITrainMovementMessageParser> _messageParsers;

        public TrainMovementParsingService(ITrainMovementMessageParser[] messageParsers)
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

                var parsedMessage = _messageParsers[key].ParseMovementMessage(message);

                response.Add(parsedMessage);
            }

            return response;
        }
    }
}