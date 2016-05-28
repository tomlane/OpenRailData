using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberStorageService : ITrainDescriberStorageService
    {
        private readonly Dictionary<TrainDescriberMessageType, ITrainDescriberStorageProcessor> _storageProcessors;

        public TrainDescriberStorageService(ITrainDescriberStorageProcessor[] storageProcessors)
        {
            if (storageProcessors == null)
                throw new ArgumentNullException(nameof(storageProcessors));

            _storageProcessors = storageProcessors.ToDictionary(x => x.MessageType, x => x);
        }

        public async Task StoreDescriberMessages(IEnumerable<ITrainDescriberMessage> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            foreach (var trainDescriberMessage in messages)
            {
                await _storageProcessors[trainDescriberMessage.MessageType].ProcessMessage(trainDescriberMessage);
            }
        }
    }
}