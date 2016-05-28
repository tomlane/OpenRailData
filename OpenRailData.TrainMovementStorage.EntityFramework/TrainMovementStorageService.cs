using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

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

        public async Task StoreTrainMovementMessages(IEnumerable<ITrainMovementMessage> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            foreach (var trainMovementMessage in messages)
            {
                await _storageProcessors[trainMovementMessage.MessageType].ProcessMessage(trainMovementMessage);
            }
        }
    }
}