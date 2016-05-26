using System;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementsUnitOfWork : IDisposable
    {
        ITrainActivationRepository TrainActivations { get; }
        ITrainCancellationRepository TrainCancellations { get; }
        ITrainMovementRepository TrainMovements { get; }
        ITrainReinstatementRepository TrainReinstatements { get; }
        IChangeOfOriginRepository ChangeOfOrigins { get; }
        IChangeOfIdentityRepository ChangeOfIdentities { get; }

        int Complete();
    }
}