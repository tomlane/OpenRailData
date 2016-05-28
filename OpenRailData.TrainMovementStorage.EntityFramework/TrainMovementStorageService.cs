using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class TrainMovementStorageService : ITrainMovementStorageService
    {
        private readonly ITrainMovementsUnitOfWorkFactory _unitOfWorkFactory;

        public TrainMovementStorageService(ITrainMovementsUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task StoreTrainMovementMessages(IEnumerable<ITrainMovementMessage> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            var trainMovementMessages = messages as IList<ITrainMovementMessage> ?? messages.ToList();
            
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                await unitOfWork.TrainActivations.InsertMultipleRecordsAsync(trainMovementMessages.OfType<TrainActivation>());
                await unitOfWork.TrainCancellations.InsertMultipleRecordsAsync(trainMovementMessages.OfType<TrainCancellation>());
                await unitOfWork.TrainMovements.InsertMultipleRecordsAsync(trainMovementMessages.OfType<TrainMovement>());
                await unitOfWork.TrainReinstatements.InsertMultipleRecordsAsync(trainMovementMessages.OfType<TrainReinstatement>());
                await unitOfWork.ChangeOfOrigins.InsertMultipleRecordsAsync(trainMovementMessages.OfType<ChangeOfOrigin>());
                await unitOfWork.ChangeOfIdentities.InsertMultipleRecordsAsync(trainMovementMessages.OfType<ChangeOfIdentity>());

                unitOfWork.Complete();
            }
        }
    }
}