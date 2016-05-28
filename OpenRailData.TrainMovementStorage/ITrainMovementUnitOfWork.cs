﻿using System;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementUnitOfWork : IDisposable
    {
        ITrainMovementRepository<TrainActivation> TrainActivations { get; }
        ITrainMovementRepository<TrainCancellation> TrainCancellations { get; }
        ITrainMovementRepository<TrainMovement> TrainMovements { get; }
        ITrainMovementRepository<TrainReinstatement> TrainReinstatements { get; }
        ITrainMovementRepository<ChangeOfOrigin> ChangeOfOrigins { get; }
        ITrainMovementRepository<ChangeOfIdentity> ChangeOfIdentities { get; }

        int Complete();
    }
}