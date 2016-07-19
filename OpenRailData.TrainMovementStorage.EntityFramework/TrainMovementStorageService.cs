using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class TrainMovementStorageService : ITrainMovementStorageService
    {
        private readonly Dictionary<TrainMovementMessageType, ITrainMovementStorageProcessor> _storageProcessors;

        public TrainMovementStorageService(ITrainMovementStorageProcessor[] storageProcessors)
        {
            if (storageProcessors == null)
                throw new ArgumentNullException(nameof(storageProcessors));

            _storageProcessors = storageProcessors.ToDictionary(x => x.MessageType, x => x);
        }

        public async Task Store(IEnumerable<ITrainMovementMessage> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            foreach (var trainMovementMessage in messages)
            {
                await _storageProcessors[trainMovementMessage.MessageType].ProcessMessage(trainMovementMessage);
            }
        }

        public async Task Store(ITrainMovementMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            await _storageProcessors[message.MessageType].ProcessMessage(message);
        }
    }
}