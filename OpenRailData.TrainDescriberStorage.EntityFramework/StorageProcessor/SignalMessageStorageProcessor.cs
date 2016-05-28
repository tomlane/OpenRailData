using System;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.StorageProcessor
{
    public class SignalMessageStorageProcessor : ITrainDescriberStorageProcessor
    {
        private readonly ITrainDescriberUnitOfWorkFactory _unitOfWorkFactory;

        public TrainDescriberMessageType MessageType { get; } = TrainDescriberMessageType.SignalMessage;

        public SignalMessageStorageProcessor(ITrainDescriberUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ProcessMessage(ITrainDescriberMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                await unitOfWork.SignalMessages.InsertRecordAsync(message as SignalMessage);

                unitOfWork.Complete();
            }
        }
    }
}