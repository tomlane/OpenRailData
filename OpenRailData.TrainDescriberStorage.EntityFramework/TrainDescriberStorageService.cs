using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberStorageService : ITrainDescriberStorageService
    {
        private readonly ITrainDescriberUnitOfWorkFactory _unitOfWorkFactory;

        public TrainDescriberStorageService(ITrainDescriberUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task StoreDescriberMessages(IEnumerable<ITrainDescriberMessage> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            var trainDescriberMessages = messages as IList<ITrainDescriberMessage> ?? messages.ToList();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                await unitOfWork.BerthMessages.InsertMultipleRecordsAsync(trainDescriberMessages.OfType<BerthMessage>());
                await unitOfWork.SignalMessages.InsertMultipleRecordsAsync(trainDescriberMessages.OfType<SignalMessage>());

                unitOfWork.Complete();
            }
        }
    }
}