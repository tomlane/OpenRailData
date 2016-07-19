using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenRailData.TrainDescriber.Entities;
using OpenRailData.TrainDescriber.TrainDescriberParsing;

namespace OpenRailData.TrainDescriberParsing.Json
{
    public class TrainDescriberMessageParsingService : ITrainDescriberMessageParsingService
    {
        private readonly Dictionary<string, ITrainDescriberMessageParser> _messageParsers;

        public TrainDescriberMessageParsingService(ITrainDescriberMessageParser[] messageParsers)
        {
            if (messageParsers == null)
                throw new ArgumentNullException(nameof(messageParsers));

            _messageParsers = messageParsers.ToDictionary(x => x.DescriberMessageType, x => x);
        }

        public IEnumerable<ITrainDescriberMessage> ParseDescriberMessages(IEnumerable<string> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            var response = new List<ITrainDescriberMessage>();

            foreach (var message in messages)
            {
                var jObject = JObject.Parse(message);

                var key = jObject.Properties().Select(p => p.Name).First();

                //TODO: Change me. I am very fragile and ugly. 
                response.Add(_messageParsers[key].ParseDescriberMessage(jObject.First.Children().First().ToString()));
            }

            return response;
        }
    }
}