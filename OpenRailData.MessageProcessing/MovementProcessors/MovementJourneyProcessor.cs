using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.MessageProcessing.MovementProcessors
{
    public class MovementJourneyProcessor : ITrainMovementMessageProcessor
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainMovement;

        public Task ProcessMessage(ITrainMovementMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}