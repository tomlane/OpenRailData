using System;
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;

namespace OpenRailData.MessageProcessing.MovementProcessors
{
    public class MovementStorageProcessor : ITrainMovementMessageProcessor
    {
        private readonly ITrainMovementStorageService _storageService;

        public MovementStorageProcessor(ITrainMovementStorageService storageService)
        {
            if (storageService == null)
                throw new ArgumentNullException(nameof(storageService));

            _storageService = storageService;
        }

        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainMovement;

        public async Task ProcessMessage(ITrainMovementMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            await _storageService.Store(message);
        }
    }
}