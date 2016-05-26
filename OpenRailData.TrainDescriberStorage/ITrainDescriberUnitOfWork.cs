using System;

namespace OpenRailData.TrainDescriberStorage
{
    public interface ITrainDescriberUnitOfWork : IDisposable
    {
        IBerthMessageRepository BerthMessages { get; }
        ISignalMessageRepository SignalMessages { get; }

        int Complete();
    }
}