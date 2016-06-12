using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenRailData.Domain.TrainMovements;
using Serilog;

namespace OpenRailData.TrainMovementParsing.Json
{
    public class TrainMovementParsingService : ITrainMovementParsingService
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, ITrainMovementMessageParser> _messageParsers;

        public TrainMovementParsingService(ITrainMovementMessageParser[] messageParsers, ILogger logger)
        {
            if (messageParsers == null)
                throw new ArgumentNullException(nameof(messageParsers));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _messageParsers = messageParsers.ToDictionary(x => x.TrainMovementMessageType, x => x);
            _logger = logger;
        }

        public IEnumerable<ITrainMovementMessage> ParseTrainMovementMessages(IEnumerable<string> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            var response = new List<ITrainMovementMessage>();

            foreach (var message in messages)
            {
                try
                {
                    var key = JObject.Parse(message)["header"]["msg_type"].ToString();

                    var parsedMessage = _messageParsers[key].ParseMovementMessage(message);

                    response.Add(parsedMessage);

                    _logger.Information("Succesfully parsed message of type {key}. Input: {message} Result: {parsedMessage}", key, parsedMessage, message);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, message);
                }
            }

            return response;
        }
    }
}