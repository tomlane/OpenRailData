using System;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementStorage;

namespace OpenRailData.MessageProcessing.ActivationProcessors
{
    public class ActivationStorageProcessor : ITrainMovementMessageProcessor
    {
        private readonly ITrainMovementStorageService _storageService;

        public ActivationStorageProcessor(ITrainMovementStorageService storageService)
        {
            if (storageService == null)
                throw new ArgumentNullException(nameof(storageService));

            _storageService = storageService;
        }

        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainActivation;

        public async Task ProcessMessage(ITrainMovementMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            await _storageService.Store(message);
        }
    }
}