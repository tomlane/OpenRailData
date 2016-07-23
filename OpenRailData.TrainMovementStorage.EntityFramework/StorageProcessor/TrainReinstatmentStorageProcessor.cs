using System;
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;

namespace OpenRailData.TrainMovementStorage.EntityFramework.StorageProcessor
{
    public class TrainReinstatmentStorageProcessor : ITrainMovementStorageProcessor
    {
        private readonly ITrainMovementUnitOfWorkFactory _unitOfWorkFactory;
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainReinstatement;

        public TrainReinstatmentStorageProcessor(ITrainMovementUnitOfWorkFactory unitOfWorkFactory)
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
                await unitOfWork.TrainReinstatements.InsertRecord(message as TrainReinstatement);

                unitOfWork.Complete();
            }
        }
    }
}