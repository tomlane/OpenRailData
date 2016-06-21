﻿using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.MessageProcessing.CancellationProcessors
{
    public class CancellationJourneyProcessor : ITrainMovementMessageProcessor
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainCancellation;

        public Task ProcessMessage(ITrainMovementMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}