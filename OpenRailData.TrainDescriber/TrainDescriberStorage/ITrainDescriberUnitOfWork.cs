using System;
using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberStorage
{
    public interface ITrainDescriberUnitOfWork : IDisposable
    {
        ITrainDescriberRepository<BerthMessage> BerthMessages { get; }
        ITrainDescriberRepository<SignalMessage> SignalMessages { get; }

        int Complete();
    }
}