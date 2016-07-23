using System;
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;

namespace OpenRailData.TrainMovementStorage.EntityFramework.StorageProcessor
{
    public class TrainCancellationStorageProcessor : ITrainMovementStorageProcessor
    {
        private readonly ITrainMovementUnitOfWorkFactory _unitOfWorkFactory;

        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainCancellation;

        public TrainCancellationStorageProcessor(ITrainMovementUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ProcessMessage(ITrainMovementMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                await unitOfWork.TrainCancellations.InsertRecord(message as TrainCancellation);

                unitOfWork.Complete();
            }
        }
    }
}