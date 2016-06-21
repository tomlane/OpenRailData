﻿using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.MessageProcessing.ReinstatementProcessors
{
    public class ReinstatementJourneyProcessor : ITrainMovementMessageProcessor
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainReinstatement;

        public Task ProcessMessage(ITrainMovementMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}