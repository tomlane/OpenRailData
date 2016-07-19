using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.MessageProcessing
{
    public class TrainMovementProcessingService : ITrainMovementProcessingService
    {
        private readonly Dictionary<TrainMovementMessageType, ITrainMovementMessageProcessor> _messageProcessors;

        public TrainMovementProcessingService(ITrainMovementMessageProcessor[] processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors));

            _messageProcessors = processors.ToDictionary(x => x.MessageType, x => x);
        }

        public async Task Process(ITrainMovementMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            await _messageProcessors[message.MessageType].ProcessMessage(message);
        }

        public async Task Process(IEnumerable<ITrainMovementMessage> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            foreach (var trainMovementMessage in messages)
            {
                await _messageProcessors[trainMovementMessage.MessageType].ProcessMessage(trainMovementMessage);
            }
        }
    }
}