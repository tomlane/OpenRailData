using System;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage
{
    public interface ITrainDescriberUnitOfWork : IDisposable
    {
        ITrainDescriberRepository<BerthMessage> BerthMessages { get; }
        ITrainDescriberRepository<SignalMessage> SignalMessages { get; }

        int Complete();
    }
}