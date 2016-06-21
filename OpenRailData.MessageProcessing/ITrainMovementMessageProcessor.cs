using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.MessageProcessing
{
    public interface ITrainMovementMessageProcessor
    {
        TrainMovementMessageType MessageType { get; }

        Task ProcessMessage(ITrainMovementMessage message);
    }
}