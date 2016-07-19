using System;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.TrainMovement.TrainMovementStorage
{
    public interface ITrainMovementUnitOfWork : IDisposable
    {
        ITrainMovementRepository<TrainActivation> TrainActivations { get; }
        ITrainMovementRepository<TrainCancellation> TrainCancellations { get; }
        ITrainMovementRepository<Entities.TrainMovement> TrainMovements { get; }
        ITrainMovementRepository<TrainReinstatement> TrainReinstatements { get; }
        ITrainMovementRepository<ChangeOfOrigin> ChangeOfOrigins { get; }
        ITrainMovementRepository<ChangeOfIdentity> ChangeOfIdentities { get; }

        int Complete();
    }
}